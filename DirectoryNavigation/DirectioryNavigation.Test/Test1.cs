
using DirectoryNavigation;

namespace DirectioryNavigation.Test
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            DirectoryNavigator solution = new DirectoryNavigator();
            string[] input = [
                "cd /home",
                "cd user",
                "pwd",
                "cd ..",
                "pwd",
                "cd ./projects/../code",
                "pwd"
                ];
            string[] output = [
                "/home/user/",
                "/home/",
                "/home/code/"
                ];

            // Act
            string[] result = solution.Solve(input);

            // Assert
            for(int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], result[i]);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            DirectoryNavigator solution = new DirectoryNavigator();
            string[] input = [
                "cd /",
                "cd home",
                "cd ./user//",
                "cd ../..",
                "cd ../..",
                "cd var/log",
                "pwd",
                "cd /etc/./nginx/../ssh",
                "pwd",
                "cd ..",
                "pwd"
                ];
            string[] output = [
                "/var/log/",
                "/etc/ssh/",
                "/etc/"
                ];

            // Act
            string[] result = solution.Solve(input);

            // Assert
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output[i], result[i]);
            }
        }
    }
}
