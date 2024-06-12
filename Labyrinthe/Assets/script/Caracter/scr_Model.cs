using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class scr_Model
{
    #region - Player -

    [Serializable]
    public class PlayerSettingModel
    {
        public float ViewXSensitivity;
        public float ViewYSensitivity;

        public bool ViewXInverted;
        public bool ViewYInverted;

        [Header("Movement")]
        public float WalkingForwardSpeed;
        public float WalkingStrafeSpeed;
        public float WalkingBackwardSpeed;

        [Header("Jumping")]
        public float JumpingHeight;
        public float JumpingFalloff;

    }

    #endregion
}
