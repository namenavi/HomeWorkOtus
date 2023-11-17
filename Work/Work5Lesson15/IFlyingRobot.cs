﻿/*
 В этом ДЗ вы научитесь явному вызову интерфейсов, их наследованию и реализации методов по умолчанию.


Описание/Пошаговая инструкция выполнения домашнего задания:
Создать интерфейс IRobot с публичным методами string GetInfo() и List GetComponents(), а также string GetRobotType() с дефолтной реализацией, возвращающей значение "I am a simple robot.".
Создать интерфейс IChargeable с методами void Charge() и string GetInfo().
Создать интерфейс IFlyingRobot как наследник IRobot с дефолтной реализацией GetRobotType(), возвращающей строку "I am a flying robot.".
Создать класс Quadcopter, наследующий IFlyingRobot и IChargeable. В нём создать список компонентов List _components = new List {"rotor1","rotor2","rotor3","rotor4"} и возвращать его из метода GetComponents().
Реализовать метод Charge() должен писать в консоль "Charging..." и через 3 секунды "Charged!". Ожидание в 3 секунды реализовать через Thread.Sleep(3000).
Реализовать все методы интерфейсов в классе. До этого пункта достаточно было "throw new NotImplementedException();"
В чат напишите также время, которое вам потребовалось для реализации домашнего задания.
  */

namespace Work5Lesson15
{
    public interface IFlyingRobot : IRobot
    {
        public new string GetRobotType()
        {
           return "I am a flying robot.";
        }
    }
}