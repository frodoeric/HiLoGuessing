using HiLoGuessing.Application.Services.Interfaces;

namespace HiLoGuessing.Application.Services
{
    public class AttemptsService : IAttemptsService
    {
        //todo: separate infra repository with interface
        public List<int> GetAttempts()
        {
            //return MysteryNumberRepository.AttemptsList;
            return null;
        }

        public void IncrementAttempts()
        {
            //MysteryNumberRepository.NumberOfAttempts++;
        }

        public void ResetAttempts()
        {
            //MysteryNumberRepository.NumberOfAttempts = 0;
        }

        public void SaveAttempts()
        {
            //MysteryNumberRepository.AttemptsList.Add(MysteryNumberRepository.NumberOfAttempts);
        }
    }
}
