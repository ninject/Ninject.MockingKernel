using NUnit.Framework;

namespace Ninject.Moq.Tests
{
	[TestFixture]
	public class MockingKernelSpecs
	{
		public interface IDummyService
		{
		}

		public class DummyClass
		{
			public IDummyService DummyService { get; set; }

			public DummyClass(IDummyService dummyService)
			{
				DummyService = dummyService;
			}
		}

		[Test]
		public void Kernel_returns_same_mock_instance_for_all_requests_for_that_type()
		{
			var kernel = new MockingKernel();

			Assert.AreSame(kernel.Get<IDummyService>(), kernel.Get<IDummyService>());
		}

		[Test]
		public void Kernel_can_create_class_under_test()
		{
			var kernel = new MockingKernel();

			Assert.IsNotNull(kernel.Get<DummyClass>());
		}
	}
}