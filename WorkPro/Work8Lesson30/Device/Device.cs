﻿namespace Work8Lesson30.Device
{
    /// <summary>
    /// Базовый класс Устройство
    /// </summary>
    public abstract class Device : IMyCloneable<Device>, ICloneable
    {
        public string SerialNumber { get; set; }

        public abstract object Clone();
        public abstract Device MyClone();
    }
}
