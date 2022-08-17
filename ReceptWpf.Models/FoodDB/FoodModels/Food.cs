namespace Models.FoodDB.FoodModels;
public class Food : IEquatable<Food>
{
    public int Id { get; set; }
    public string? PreparationTime { get; set; }
    public string? DifficultyFood { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? FoodPhoto { get; set; }
    public string? Country { get; set; }
    public string? FoodTittle { get; set; }
    public string? Ingredients { get; set; }
    public string? Pretensions { get; set; }
    public string? CreatedBy { get; set; }

    public bool Equals(Food? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return PreparationTime == other.PreparationTime && DifficultyFood == other.DifficultyFood && FoodPhoto == other.FoodPhoto && Country == other.Country && FoodTittle == other.FoodTittle && Ingredients == other.Ingredients && Pretensions == other.Pretensions && CreatedBy == other.CreatedBy;
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Food)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(PreparationTime);
        hashCode.Add(DifficultyFood);
        hashCode.Add(FoodPhoto);
        hashCode.Add(Country);
        hashCode.Add(FoodTittle);
        hashCode.Add(Ingredients);
        hashCode.Add(Pretensions);
        hashCode.Add(CreatedBy);
        return hashCode.ToHashCode();
    }
}