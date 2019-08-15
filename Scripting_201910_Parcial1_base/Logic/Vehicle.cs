namespace Scripting_201910_Parcial1_base.Logic
{
    public abstract class Vehicle
    {
        protected float baseMaxSpeed;

        protected int Level { get; set; }
       

        protected abstract VehicleType Type { get; }

        protected Part CurrentPart { get; set; }

        public float MaxSpeed
        {
            get
            {
                float result = baseMaxSpeed * (1 + Level * 0.05f) ;

                if(CurrentPart != null)
                {
                    result *= 1 + CurrentPart.SpeedBonus;
                }
                return result;
            }
        }

        public Vehicle()
        {
        }

        public Vehicle(float _baseMaxSpeed)
        {
            baseMaxSpeed = _baseMaxSpeed;
            Level = 0;
            CurrentPart = null;
        }

        public bool Equip(Part part)
        {
            bool result = false;

            if (Type == part.Type || part.Type == VehicleType.Any)
            {
                CurrentPart = part;
                result = true;
            }

            return result;
        }

        public void Upgrade()
        {
            Level += 1;
            if (CurrentPart != null && Level != 3)
            {
                CurrentPart.Upgrade();
            }
        }
    }
}