namespace Scripting_201910_Parcial1_base.Logic
{
    public abstract class Part
    {
        protected float speedBonus;
        
        public int Level { get; protected set; }
        public abstract VehicleType Type { get; }
        public float Durability {
            get {
                float result;
                if (Durability > 1)
                {
                    result = 1;
                }else if(Durability < 0){
                    result = 0;
                }else
                {
                    result = Durability;
                }
                return result;
            }
        }

        public float SpeedBonus
        {
            get { return speedBonus = (speedBonus*(1+ Level*0.03f))*Durability; }
            protected set { speedBonus = value; }
        }

        public Part()
        {
        }

        public Part(float speedBonus)
        {
            Level = 0;
            if(speedBonus > 0.5f)
            {
                SpeedBonus = 0.5f;
            }
            else
            {
                SpeedBonus = speedBonus;
            }
        }

        public void Upgrade()
        {
            Level += 1;
           
        }
    }
}