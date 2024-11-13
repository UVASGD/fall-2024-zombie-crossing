namespace ZombieCrossing.TransformUtility.Runtime
{
    [System.Flags] public enum Axis
    {
        None = 0, 
        X = 1 << 0, 
        Y = 1 << 1,
        Z = 1 << 2,
    }
}