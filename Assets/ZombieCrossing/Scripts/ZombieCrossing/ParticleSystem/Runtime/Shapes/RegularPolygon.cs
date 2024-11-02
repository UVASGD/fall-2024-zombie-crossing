using UnityEngine;

namespace ZombieCrossing.ParticleSystem.Runtime.Shapes
{
    [System.Serializable]
    public class RegularPolygon: IShape
    {
        /// <summary>
        /// The angle of each face of the polygon
        /// </summary>
        [SerializeField, Range(0, 360)] 
        private float dihedralAngle; 
        
        public Vector3 ConvertToShapeDirection(Vector3 direction)
        {
            switch (dihedralAngle)
            {
                case 0:
                    return direction;
                case 360:
                    return Vector3.up;
            }

            var snapAngleRadians = dihedralAngle * Mathf.Deg2Rad;
            
            var theta = Mathf.Atan2(direction.z, direction.x);
            var phi = Mathf.Acos(direction.y); 
            var snappedTheta = Mathf.Round(theta / snapAngleRadians) * snapAngleRadians;
            var snappedPhi = Mathf.Round(phi / snapAngleRadians) * snapAngleRadians;
            
            var snappedDirection = ConvertSphericalToCartesianDirection(snappedTheta, snappedPhi);
            
            return snappedDirection;
        }
        
        private Vector3 ConvertSphericalToCartesianDirection(float theta, float phi)
        {
            float x;
            float y;
            float z; 
            
            // Handle the edge case where theta is ±π
            if (Mathf.Approximately(Mathf.Abs(theta), Mathf.PI))
            {
                var sign = Mathf.Sign(theta);
                x = sign * Mathf.Cos(theta);
                y = 0;
                z = sign * Mathf.Sin(theta);
            }
            else
            {
                x = Mathf.Sin(phi) * Mathf.Cos(theta);
                y = Mathf.Cos(phi);
                z = Mathf.Sin(phi) * Mathf.Sin(theta);
            }

            return new Vector3(x, y, z);
        }
    }
}