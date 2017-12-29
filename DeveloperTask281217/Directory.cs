using System;
using System.Collections.Generic;

namespace DeveloperTask281217
{
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> mChildrenList;

        public Directory(Directory iParentDir, string iDirName)
        {
            Name = iDirName;
            mParentDir = iParentDir;
            mChildrenList = new List<FileSystemComponent>();
            mCreationDate = DateTime.Now.Date;
        }

        // Return a reference to the created file
        public File AddChildFile(string iFileName, long iFileSize)
        {
            File newChildFile = new File(this, iFileName, iFileSize);
            mChildrenList.Add(newChildFile);

            return newChildFile;
        }

        // Return a reference to the created directory
        public Directory AddChildDir(string iDirName)
        {
            Directory newChildDir = new Directory(this, iDirName);
            mChildrenList.Add(newChildDir);

            return newChildDir;
        }

        // Return true if deleted, false if doesn't exist
        public bool DeleteChild(string iChildName)
        {
            FileSystemComponent childToDelete = null;
            foreach (var component in mChildrenList)
            {
                if (component.Name == iChildName)
                {
                    childToDelete = component;
                    break;
                }   
            }

            if (childToDelete != null)
            {
                mChildrenList.Remove(childToDelete);
                return true;
            }
            else
                return false; 
        }

        // Print data and content to console
        public override void Show(string iLeadingTabsStr)
        {
            Console.WriteLine(string.Format("+{0} | Created: {1}", Name, mCreationDate.ToShortDateString()));
            foreach (var child in mChildrenList)
            {
                Console.Write(iLeadingTabsStr + "\t");
                child.Show(iLeadingTabsStr + "\t");
            }
        }
    }
}
