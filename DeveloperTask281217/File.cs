using System;

namespace DeveloperTask281217
{
    public class File : FileSystemComponent
    {
        private long mSize;

        public File(Directory iParentDir, string iFileName, long iFileSize)
        {
            Name = iFileName;
            mParentDir = iParentDir;
            mCreationDate = DateTime.Now.Date;
            mSize = iFileSize;
        }

        public long Size
        {
            get { return mSize; }
        }

        // Print data to console
        public override void Show(string iLeadingTabsStr)
        {
            Console.WriteLine(string.Format("{0} | Size: {1} | Created: {2}", Name, mSize, mCreationDate.ToShortDateString()));
        }
    }
}
