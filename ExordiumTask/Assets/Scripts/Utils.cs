using UnityEngine;

namespace Character.Utils
{
    public enum MovementState
    {
        Steady,
        UpwardMoving,
        LeftMoving,
        RightMoving,
        DownwardMoving
    }

    public enum UsageType
    {
        PermanentUsage,
        Pickup,

    }


    public enum SlotEquipType
    {
        None,
        Head,
        Torso,
        MainHand,
        OffHand

    }

}