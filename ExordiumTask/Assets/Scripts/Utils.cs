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
        Pickup

    }


    public enum EquipmentType
    {
        Helmet,
        Armor,
        Sword,
        Shield

    }

    public enum StackType
    {
        Unlimited,
        Limited
    }

}