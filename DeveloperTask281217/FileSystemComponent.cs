using System;

namespace DeveloperTask281217
{
    // This abstract class represents either a file or a directory - they inherit from it
    public abstract class FileSystemComponent
    {
        public string Name { get; set; }
        protected DateTime mCreationDate;
        protected Directory mParentDir;

        public Directory ParentDir
        {
            get { return mParentDir; }
        }

        public abstract void Show(string iLeadingTabsStr);
        
    }
}
