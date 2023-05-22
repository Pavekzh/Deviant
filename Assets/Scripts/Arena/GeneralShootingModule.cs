using System;
using System.Collections;
using UnityEngine;

namespace Arena
{
    public class GeneralShootingModule : ShootingModule
    {
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float fireRate = 1;
        [SerializeField] int shotsToOverheat = 5;
        [SerializeField] float cooldownTime = 5;
        [SerializeField] bool animateCooldown = false;
        [SerializeField] bool preciseCooldown = true;
        [SerializeField] bool animateReload = false;
        [SerializeField] bool preciseReload = true;

        [SerializeField]protected float heatLevel = 0;        
        protected const float maxHeatLevel = 100;
        protected bool isOverheated = false;

        [SerializeField]protected float reloadProgress;
        protected bool isReloading = false;

        [SerializeField]protected int shotsCount = 0;


        protected float reloadTime { get => 1 / fireRate; }
        protected float heatingPerShoot { get => maxHeatLevel / shotsToOverheat; }
        protected float cooldownPerSecond { get => maxHeatLevel / cooldownTime; }

        bool needToSaveReloadProgress;
        bool needToSaveCooldownProgress;

        float reloadStartTime;
        float cooldownStartTime;

        public override event Action ShootingStarted;
        public override event Action ShootingPaused;

        public override void StartShooting()
        {
            StopAllCoroutines();

            if (needToSaveReloadProgress)
                SaveProgress(Time.realtimeSinceStartup - reloadStartTime, reloadTime, 100, ref reloadProgress, (x, y) => y + x);
            if (needToSaveCooldownProgress)
                SaveProgress(Time.realtimeSinceStartup - cooldownStartTime, cooldownTime, maxHeatLevel, ref heatLevel, (x, y) => y - x);

                StartCoroutine(Shooting());
        }

        public override void StopShooting()
        {
            StopAllCoroutines();

            StartCoroutine(Preparation());

        }

        private IEnumerator Preparation()
        {

            if (needToSaveReloadProgress)
                SaveProgress(Time.realtimeSinceStartup - reloadStartTime, reloadTime, 100, ref reloadProgress, (x, y) => y + x);
            if (needToSaveCooldownProgress)
                SaveProgress(Time.realtimeSinceStartup - cooldownStartTime, cooldownTime, maxHeatLevel, ref heatLevel, (x, y) => y - x);


            if (isReloading)
            {
                needToSaveCooldownProgress = false;
                yield return StartCoroutine(Reload());
            }
            if (heatLevel > 0)
            {

                yield return StartCoroutine(Cooldown());
            }
        }

        protected virtual void Shoot()
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.LookAt(Target);
            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
            if(projectileController != null)
            {
                projectileController.Target = this.Target;
                projectileController.Shoot();
            }
            else
                Debug.LogError("Pjectile has no projectile controller");


            shotsCount++;            
            heatLevel += heatingPerShoot;
            reloadProgress = 0;
            if (Mathf.Approximately(heatLevel, maxHeatLevel) || heatLevel > maxHeatLevel)
            {
                isOverheated = true;
            }
        }

        protected  IEnumerator Shooting()
        {
            if (isOverheated)
            {
                yield return StartCoroutine(Cooldown());               
            }

            if (isReloading)
            {
                yield return StartCoroutine(Reload());
            }

            while (true)
            {
                ShootingStarted?.Invoke();
                while (!isOverheated)
                {
                    Shoot();
                    isReloading = true;
                    yield return StartCoroutine(Reload());
                }
                yield return StartCoroutine(Cooldown());
            }

        }

        protected IEnumerator Cooldown()
        {
            ShootingPaused?.Invoke();
            if (animateCooldown)
            {
                while (!Mathf.Approximately(heatLevel, 0) && heatLevel > 0)
                {
                    yield return null;
                    heatLevel -= Time.deltaTime * cooldownPerSecond;
                }
            }
            else
            {
                if(preciseCooldown)
                    needToSaveCooldownProgress = true;
                cooldownStartTime = Time.realtimeSinceStartup;
                yield return new WaitForSeconds(cooldownTime * (heatLevel / maxHeatLevel));
                needToSaveCooldownProgress = false;
            }

            heatLevel = 0;
            isOverheated = false;
        }

        protected IEnumerator Reload()
        {
            if (animateReload)
            {
                while(!Mathf.Approximately(reloadProgress,100) && reloadProgress < 100)
                {
                    yield return null;
                    reloadProgress += Time.deltaTime * (100 / reloadTime);
                }
            }
            else
            {
                if(preciseReload)
                    needToSaveReloadProgress = true;
                reloadStartTime = Time.realtimeSinceStartup;
                yield return new WaitForSeconds(reloadTime * ((100 - reloadProgress) / 100));
                needToSaveReloadProgress = false;
            }

            reloadProgress = 100;
            isReloading = false;
        }

        private void SaveProgress(float elapsedTime,float timeToComplete,float valueRange,ref float toSave, System.Func<float,float,float> writeProgressFunc )
        {
            float progress = elapsedTime / timeToComplete;
            float value = progress * valueRange;
            toSave = writeProgressFunc(value,toSave);
        }

    }
}