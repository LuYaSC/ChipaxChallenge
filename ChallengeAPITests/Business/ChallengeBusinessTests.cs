using ChallengeAPI.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeAPI.Business.Tests.Business
{
    [TestClass()]
    public class ChallengeBusinessTests : UnitTestManager
    {

        [TestMethod()]
        public void ResponseExercise1Test()
        {
            var result = new ChallengeBusiness(Configuration).ResponseExercise1();
            Assert.IsTrue(result.In_time);
        }

        [TestMethod()]
        public void NotOptimizedResponseExercise1Test()
        {
            var result = new ChallengeBusiness(Configuration).ResponseExercise1(0, false);
            Assert.IsTrue(result.In_time);
        }


        [TestMethod()]
        public void ResponseExercise2Test()
        {
            var result = new ChallengeBusiness(Configuration).ResponseExercise2();
            Assert.IsTrue(result.In_time);
        }

        [TestMethod()]
        public void NotOptimizedResponseExercise2Test()
        {
            var result = new ChallengeBusiness(Configuration).ResponseExercise2(0, false);
            Assert.IsTrue(result.In_time);
        }
    }
}