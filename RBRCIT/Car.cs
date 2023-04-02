
namespace RBRCIT
{

    public struct Car
    {
        //from carList.ini
        public string nr;
        public string name;
        public string physics;
        public string cat;
        public string iniFile;
        public string folder;
        public string trans;
        public string link_physics;
        public string link_model;
        public string link_banks;

        //extended 
        public string manufacturer;
        public string year;
        public int power;
        public int weight;
        public bool model_exists;
        public bool physics_exists;
        public bool banks_exist;
        public string banks;  //base filename for FMOD SoundBanks

        public CarUserSettings userSettings;
    }

    public struct CarUserSettings
    {
        public string engineSound;
        public string FMODSoundBank;
        public bool hideSteeringWheel;
        public bool hideWipers;
        public bool hideWindShield;
        public bool mirrorSteeringWheel;
    }


}
