using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.AI_Scrtips.AIStructs
{
    class SMovement
    {
        public struct StMovement
        {
            public float rotation;
            public float time;
            public float velocity;
            public float rotVelocity;

            public StMovement(float pRotation, float pTime, float pVelocity, float pRotVelocity)
            {
                rotation = pRotation;
                time = pTime;
                velocity = pVelocity;
                rotVelocity = pRotVelocity;
            }
        }
    }
}
