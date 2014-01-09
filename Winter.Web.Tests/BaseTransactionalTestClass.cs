using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace Winter.Web.Tests
{
    [TestClass]
    public abstract class BaseTransactionalTestClass
    {
        private TransactionScope scope = null;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                });
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            if (scope != null)
            {
                scope.Dispose();
                scope = null;
            }
        }
    }
}
