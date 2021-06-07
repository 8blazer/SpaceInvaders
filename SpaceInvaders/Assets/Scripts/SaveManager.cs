using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

public class SaveManager : MonoBehaviour
{
    public int playCount = -1;
    public string easyMode; // "unbeaten", "beaten", "noContinue", "noDeath"
    public string normalMode;
    public string hardMode;
    public int endlessKills;
    public bool machinegunChallenge;
    public bool minigunChallenge;
    public bool shotgunChallenge;
    public bool laserChallenge;
    public bool sniperChallenge;
    public bool rocketChallenge;
    public bool gEnemyChallenge;
    public bool rEnemyChallenge;
    public bool oEnemyChallenge;
    public bool cEnemyChallenge;
    public bool pEnemyChallenge;
    public bool yEnemyChallenge;
    public bool slowChallenge;
    public bool fastChallenge;
    public bool noAbilityChallenge;
    public bool ammoChallenge;
    public bool crazyEnemyChallenge;
    public bool upsideDownChallenge;
    public int weaponChallenges;
    public int enemyChallenges;
    public int otherChallenges;
    public bool music;
    public bool sound;

    bool created = false;
    
    void Awake()
    {
        if (!created)
        {
            created = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string saveFile = "save.txt";
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        if (playCount == -1)
        {
            if (!File.Exists(fullname))
            {
                SaveVars saveVars = new SaveVars
                {
                    PlayCount = 0,
                    EasyMode = "unbeaten",
                    NormalMode = "unbeaten",
                    HardMode = "unbeaten",
                    EndlessKills = 0,
                    MachinegunChallenge = false,
                    MinigunChallenge = false,
                    ShotgunChallenge = false,
                    LaserChallenge = false,
                    SniperChallenge = false,
                    RocketChallenge = false,
                    GEnemyChallenge = false,
                    REnemyChallenge = false,
                    OEnemyChallenge = false,
                    CEnemyChallenge = false,
                    PEnemyChallenge = false,
                    YEnemyChallenge = false,
                    SlowChallenge = false,
                    FastChallenge = false,
                    NoAbilityChallenge = false,
                    AmmoChallenge = false,
                    CrazyEnemyChallenge = false,
                    UpsideDownChallenge = false,
                    WeaponChallenges = 0,
                    EnemyChallenges = 0,
                    OtherChallenges = 0,
                    Music = true,
                    Sound = true,
                };

                playCount = saveVars.PlayCount;
                easyMode = saveVars.EasyMode;
                normalMode = saveVars.NormalMode;
                hardMode = saveVars.HardMode;
                endlessKills = saveVars.EndlessKills;
                machinegunChallenge = saveVars.MachinegunChallenge;
                minigunChallenge = saveVars.MinigunChallenge;
                shotgunChallenge = saveVars.ShotgunChallenge;
                laserChallenge = saveVars.LaserChallenge;
                sniperChallenge = saveVars.SniperChallenge;
                rocketChallenge = saveVars.RocketChallenge;
                gEnemyChallenge = saveVars.GEnemyChallenge;
                rEnemyChallenge = saveVars.REnemyChallenge;
                oEnemyChallenge = saveVars.OEnemyChallenge;
                pEnemyChallenge = saveVars.PEnemyChallenge;
                cEnemyChallenge = saveVars.CEnemyChallenge;
                yEnemyChallenge = saveVars.YEnemyChallenge;
                slowChallenge = saveVars.SlowChallenge;
                fastChallenge = saveVars.FastChallenge;
                noAbilityChallenge = saveVars.NoAbilityChallenge;
                ammoChallenge = saveVars.AmmoChallenge;
                crazyEnemyChallenge = saveVars.CrazyEnemyChallenge;
                upsideDownChallenge = saveVars.UpsideDownChallenge;
                weaponChallenges = saveVars.WeaponChallenges;
                enemyChallenges = saveVars.EnemyChallenges;
                otherChallenges = saveVars.OtherChallenges;
                music = saveVars.Music;
                sound = saveVars.Sound;

                string json = JsonUtility.ToJson(saveVars);
                File.WriteAllText(fullname, json);
            }
            else
            {
                string jsonString = File.ReadLines(fullname).First();
                SaveVars jsonJson = JsonUtility.FromJson<SaveVars>(jsonString);
                playCount = jsonJson.PlayCount;
                easyMode = jsonJson.EasyMode;
                normalMode = jsonJson.NormalMode;
                hardMode = jsonJson.HardMode;
                endlessKills = jsonJson.EndlessKills;
                machinegunChallenge = jsonJson.MachinegunChallenge;
                minigunChallenge = jsonJson.MinigunChallenge;
                shotgunChallenge = jsonJson.ShotgunChallenge;
                laserChallenge = jsonJson.LaserChallenge;
                sniperChallenge = jsonJson.SniperChallenge;
                rocketChallenge = jsonJson.RocketChallenge;
                gEnemyChallenge = jsonJson.GEnemyChallenge;
                rEnemyChallenge = jsonJson.REnemyChallenge;
                oEnemyChallenge = jsonJson.OEnemyChallenge;
                pEnemyChallenge = jsonJson.PEnemyChallenge;
                cEnemyChallenge = jsonJson.CEnemyChallenge;
                yEnemyChallenge = jsonJson.YEnemyChallenge;
                slowChallenge = jsonJson.SlowChallenge;
                fastChallenge = jsonJson.FastChallenge;
                noAbilityChallenge = jsonJson.NoAbilityChallenge;
                ammoChallenge = jsonJson.AmmoChallenge;
                upsideDownChallenge = jsonJson.UpsideDownChallenge;
                crazyEnemyChallenge = jsonJson.CrazyEnemyChallenge;
                weaponChallenges = jsonJson.WeaponChallenges;
                enemyChallenges = jsonJson.EnemyChallenges;
                otherChallenges = jsonJson.OtherChallenges;
                music = jsonJson.Music;
                sound = jsonJson.Sound;
            }
        }
    }

    public void ToJson()
    {
        SaveVars newSave = new SaveVars
        {
            PlayCount = playCount,
            EasyMode = easyMode,
            NormalMode = normalMode,
            HardMode = hardMode,
            EndlessKills = endlessKills,
            MachinegunChallenge = machinegunChallenge,
            MinigunChallenge = minigunChallenge,
            ShotgunChallenge = shotgunChallenge,
            LaserChallenge = laserChallenge,
            SniperChallenge = sniperChallenge,
            RocketChallenge = rocketChallenge,
            GEnemyChallenge = gEnemyChallenge,
            REnemyChallenge = rEnemyChallenge,
            OEnemyChallenge = oEnemyChallenge,
            PEnemyChallenge = pEnemyChallenge,
            CEnemyChallenge = cEnemyChallenge,
            YEnemyChallenge = yEnemyChallenge,
            SlowChallenge = slowChallenge,
            FastChallenge = fastChallenge,
            NoAbilityChallenge = noAbilityChallenge,
            AmmoChallenge = ammoChallenge,
            CrazyEnemyChallenge = crazyEnemyChallenge,
            UpsideDownChallenge = upsideDownChallenge,
            WeaponChallenges = weaponChallenges,
            EnemyChallenges = enemyChallenges,
            OtherChallenges = otherChallenges,
            Sound = sound,
            Music = music,
        };
        string saveFile = "save.txt";
        FileInfo fileInfo = new FileInfo(saveFile);
        string fullname = fileInfo.FullName;
        string json = JsonUtility.ToJson(newSave);
        File.Delete(fullname);
        File.WriteAllText(fullname, json);
    }
}

[Serializable]
public class SaveVars
{
    public int PlayCount;
    public string EasyMode;
    public string NormalMode;
    public string HardMode;
    public int EndlessKills;
    public bool MachinegunChallenge;
    public bool MinigunChallenge;
    public bool ShotgunChallenge;
    public bool LaserChallenge;
    public bool SniperChallenge;
    public bool RocketChallenge;
    public bool GEnemyChallenge;
    public bool REnemyChallenge;
    public bool OEnemyChallenge;
    public bool CEnemyChallenge;
    public bool PEnemyChallenge;
    public bool YEnemyChallenge;
    public bool SlowChallenge;
    public bool FastChallenge;
    public bool NoAbilityChallenge;
    public bool AmmoChallenge;
    public bool CrazyEnemyChallenge;
    public bool UpsideDownChallenge;
    public int WeaponChallenges;
    public int EnemyChallenges;
    public int OtherChallenges;
    public bool Music;
    public bool Sound;
}
