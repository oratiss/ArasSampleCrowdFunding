namespace Aras.SampleCrowdFunding.UtilityService.PaginationUtilities
{
    public abstract class Pagination
    {
        protected Pagination()
        {
            var validatePagination = ValidatePagination;
            validatePagination();
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public string? OrderBy { get; set; }

        public SortOrder? SortOrder { get; set; }

        public abstract void ValidatePagination();
    }
}
