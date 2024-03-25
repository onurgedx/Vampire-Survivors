
namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public struct Experience
    {
        public static Experience Zero = new Experience(0);

        public int Value { get; private set; }
            
        public Experience(int a_experienceValue)
        {
            Value = a_experienceValue;
        }        


        public static implicit operator Experience(int a_value)
        {
            return new Experience(a_value);
        }
        
        public static int operator + (Experience a, Experience b)
        {
            return a.Value + b.Value;
        }
        public static int operator -(Experience a, Experience b)
        {
            return a.Value - b.Value;
        }
    }
}