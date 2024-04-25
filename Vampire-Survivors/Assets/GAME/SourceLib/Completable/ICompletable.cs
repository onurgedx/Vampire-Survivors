using System; 
namespace VampireSurvivors.Lib.Basic.Completables
{
    public interface ICompletable<T>
    {        
        public T Value { get; }

        public void RunOnCompleted(Action a_void);
    }
}