using System;
using System.Text;

namespace Assesment1
{
    
         /// <summary>
        ///  Program to calculate shell horizontal traval distance and height from user input 
       ///  of angle in degree and speed
      ///For the course Begining game programming in C# at coursera
     ///Author: Laurent Morissette
     ///
    ///</summary>
    ///
    class Program
    {
        const string INVITE = "Hi, this application will calculate the maximum height of the shell\n and the distance it will travel along the ground";
        const string PROVIDE_ANGLE = "Please, give the initial angle in degrees: ";
        const string PROVIDE_SPEED = "Please, give the initial speed: ";
        const string RESULT_HEIGHT = "Maximum shell height: ";
        const string RESULT_DISTANCE = "Horizontal distance: ";
        const string METERS = " meters";
        const string NUMBER_FORMAT = "#.000";

        const double g = 9.8;
     
        static void Main(string[] args)
        {
           
            Console.WriteLine(INVITE);
            Console.WriteLine();
            Console.Write(PROVIDE_ANGLE);
            float theta =0;
            Console.Write(PROVIDE_SPEED);
            float speed = float.Parse(Console.ReadLine());
            float vox = (float)(speed * Math.Cos(theta));
            float voy = (float)(speed * Math.Sin(theta));
            float t = (float)(voy / g);
            float h = (float)((voy * voy) / (2 * g));
            float dx = vox * 2 * t;
            Console.WriteLine(RESULT_HEIGHT + h.ToString(NUMBER_FORMAT)+METERS);
            Console.WriteLine(RESULT_DISTANCE + dx.ToString(NUMBER_FORMAT)+METERS);
          
                  
            }
        private static float degreeToRadian(double angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }
    }
}
