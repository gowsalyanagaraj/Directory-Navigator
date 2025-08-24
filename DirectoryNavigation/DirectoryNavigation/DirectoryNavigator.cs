namespace DirectoryNavigation
{
    public class DirectoryNavigator
    {
        public List<string> currentPath = ["/"];
        public int currentIndex = 1;

        public string[] resultPwd;
        public int resultIndex = 0;
        public string[] Solve(string[] input)
        {
            resultPwd = new string[input.Count(x => x.Equals("pwd"))];
            foreach (string s in input)
            {
                if(s.StartsWith("cd "))
                {
                    if(s.Substring(3).StartsWith("/") && currentPath.Count>0)
                    {
                        currentPath.RemoveRange(1, currentIndex - 1);
                        currentIndex = 1;
                        SplitDirectory(s.Substring(3));
                    }
                    else
                    {
                        SplitDirectory(s.Substring(3));
                    }                    
                }
                else if(s.StartsWith("pwd"))
                {
                    FindPWD();
                }
            }
            return resultPwd;
        }

        private void SplitDirectory(string path)
        {
            while(path.Length > 0)
            {
                if (path.StartsWith("//"))
                {
                    currentPath.Add("/");
                    currentIndex++;
                    path = path.Remove(0, 2);
                }
                else if (path.StartsWith("./"))
                {
                    path = path.Remove(0, 2);
                }
                else if (path.StartsWith("/"))
                {
                    path = path.Remove(0, 1);
                }
                else if(path.StartsWith("..") && currentIndex>1)
                {
                    currentIndex--;
                    currentPath.RemoveAt(currentIndex);
                    path = path.Remove(0, 2);
                }
                else if (path.StartsWith(".."))
                {
                    path = path.Remove(0, 2);
                }
                else if(path.Contains("/"))
                {
                    currentPath.Add(path.Substring(0, path.IndexOf('/'))+"/");
                    path = path.Remove(0, path.IndexOf('/'));
                    currentIndex++;
                }
                else
                {
                    currentPath.Add(path.Substring(0)+"/");
                    path = path.Remove(0);
                    currentIndex++;
                }
            }
            
        }

        private void FindPWD()
        {
            foreach(var dir in currentPath)
            {
                resultPwd[resultIndex] += dir;
            }
            resultIndex++;
        }
    }
}
