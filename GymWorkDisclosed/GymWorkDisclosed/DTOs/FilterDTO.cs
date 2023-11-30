namespace GymWorkDisclosed.DTOs;

public class FilterDTO
{
    public string FilterProperty { get; set; }
    public string FilterValue { get; set; }

    public FilterDTO(string filterProperty, string filterValue)
    {
        FilterProperty = filterProperty;
        FilterValue = filterValue;
    }
}