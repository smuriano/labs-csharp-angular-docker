using FluentValidation;
using FluentValidation.Results;

namespace Labs.Shared.ValueObjects
{
  public class ValueObject
  {
    internal ValidationResult ValidationResult { get; private set; }
    public bool IsValid { get; private set; }

    public bool Validate<TValueObject>(TValueObject valueObject, AbstractValidator<TValueObject> validator)
    {
      ValidationResult = validator.Validate(valueObject);
      return IsValid = ValidationResult.IsValid;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is ValueObject)) return false;

      var valueObject = obj as ValueObject;

      if (this.GetType() != valueObject.GetType()) return false;
      return !(valueObject is null) && ReferenceEquals(this, valueObject);
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
      if (left is null && right is null) return true;
      if (left is null || right is null) return false;

      return left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);

    public override int GetHashCode() => (GetType().GetHashCode() * 117);

    public ValueObject GetCopy() => (ValueObject)this.MemberwiseClone();
  }
}