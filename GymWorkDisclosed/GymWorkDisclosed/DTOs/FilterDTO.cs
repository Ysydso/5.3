namespace GymWorkDisclosed.DTOs;

public class FilterDto
{
    public string FilterProperty { get; set; }
    public string FilterValue { get; set; }

    public FilterDTO(string filterProperty, string filterValue)
    {
        FilterProperty = filterProperty;
        FilterValue = filterValue;
    }
}