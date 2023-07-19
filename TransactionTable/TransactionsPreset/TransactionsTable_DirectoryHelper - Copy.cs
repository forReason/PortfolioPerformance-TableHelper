namespace PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset
{
    public partial class TransactionsTable
    {
        /// <summary>
        /// contains the selected filename without extension
        /// </summary>
        /// <remarks>
        /// this is beeing used to generate the subfolder name and the filename if <see cref="TransactionsTable._SplitByMonth"/> is set to true
        /// </remarks>
        private string _FileNameWithoutExtension { get; set; }
        /// <summary>
        /// the target directory where the Table(s) should be stored at
        /// </summary>
        /// <remarks>if <see cref="TransactionsTable._SplitByMonth"/> is true, automatically contains an apropriate subfolder</remarks>
        private DirectoryInfo? _TargetDirectory { get; set; }
        /// <summary>
        /// generates the directory path depending on <see cref="TransactionsTable._SplitByMonth"/>
        /// </summary>
        /// <param name="file"></param>
        private void GenerateDirectory(FileInfo file)
        {
            if (_SplitByMonth)
            {
                if (file.Directory != null)
                {
                    _TargetDirectory = new DirectoryInfo(Path.Combine(file.Directory.ToString(), _FileNameWithoutExtension));
                }
                else _TargetDirectory = new DirectoryInfo(_FileNameWithoutExtension);
            }
            else if (file.Directory != null)
            {
                _TargetDirectory = file.Directory;
            }
        }
        /// <summary>
        /// generates the target filename
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private FileInfo GetTargetFile(DateTime time)
        {
            string name = _FileNameWithoutExtension;
            if (_SplitByMonth)
            {
                name += $"_{time.Year}-{time.Month}";
            }
            name += ".csv";
            if (_TargetDirectory != null)
            {
                name = Path.Combine(_TargetDirectory.Name, name);
            }
            FileInfo targetFile = new FileInfo(name);
            return targetFile;
        }
    }
}
