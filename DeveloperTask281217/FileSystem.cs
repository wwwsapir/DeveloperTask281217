using System.Collections.Generic;

namespace DeveloperTask281217
{
    public class FileSystem
    {
        private Directory mRootDir;
        private Dictionary<string, FileSystemComponent> mNameCompDictionary;

        public FileSystem()
        {
            mNameCompDictionary = new Dictionary<string, FileSystemComponent>();
            mRootDir = new Directory(null, "root");
            mNameCompDictionary.Add("root", mRootDir);
        }

        // Returns true if addition succeeded
        public bool AddFile(string iParentDirName, string iFileName, long iFileSize)
        {
            Directory parentDir = getParentDir(iParentDirName);
            if (parentDir == null || mNameCompDictionary.ContainsKey(iFileName))
                return false;

            File newFile = parentDir.AddChildFile(iFileName, iFileSize);
            if (newFile != null)
            {
                mNameCompDictionary.Add(iFileName, newFile);
                return true;
            }
            else
                return false;
        }

        // Returns true if addition succeeded
        public bool AddDir(string iParentDirName, string iDirName)
        {
            Directory parentDir = getParentDir(iParentDirName);
            if (parentDir == null || mNameCompDictionary.ContainsKey(iDirName))
                return false;

            Directory newDir = parentDir.AddChildDir(iDirName);
            if (newDir != null)
            {
                mNameCompDictionary.Add(iDirName, newDir);
                return true;
            }
            else
                return false;
        }

        private Directory getParentDir(string iParentDirName)
        {
            if (iParentDirName == null)
                iParentDirName = "root";

            FileSystemComponent parentDirAsComp = null;
            if (mNameCompDictionary.TryGetValue(iParentDirName, out parentDirAsComp))
            {
                return parentDirAsComp as Directory;
            }
            else
                return null;
        }

        // Returns true if deletion succeeded
        public bool Delete(string iName)
        {
            FileSystemComponent compToDelete;
            if (mNameCompDictionary.TryGetValue(iName, out compToDelete))
            {
                return compToDelete.ParentDir.DeleteChild(iName);
            }
            else
                return false;
        }

        // Prints the file system data to console
        public void ShowFileSystem()
        {
            mRootDir.Show(string.Empty);
        }
    }
}
