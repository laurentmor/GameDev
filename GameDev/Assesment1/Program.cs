using System;
using System.Text;

namespace Assesment1
{
    /**
     * <summary>
     * Program to calculate shell horizontal traval distance and height from user input 
     * of angle in degree and speed
     * For the course Begining game programming in C# at coursera
     * Author: Laurent Morissette
     * 
     * </summary>
     * */
    class Program
    {
        const string INVITE = "Hi, this application will calculate the maximum height of the shell\n and the distance it will travel along the ground";
        const string PROVIDE_ANGLE = "Please, give the initial angle in degrees: ";
        const string PROVIDE_SPEED = "Please, give the initial speed: ";
        const string RESULT_HEIGHT = "Maximum shell height: ";
        const string RESULT_DISTANCE = "Horizontal distance: ";
        const string METERS = " meters";
        const string NUMBER_FORMAT = "#.000";
        static double g =0.0;   // acceleration due to gravity
        
        static float theta = 0;    // initial angle you’ll ask the user to provide
        static float speed = 0;   // initial speed you’ll ask the user to provide
        static float vox = 0;    // x component of the velocity at start
        static float voy = 0;   // y component of the velocity at start
        static float t = 0;    // time until shell reaches apex
        static float h = 0;   // height of shell at apex
        static float dx = 0; // distance shell travels horizontally (assuming launch and target elevations a
        static void Main(string[] args)
        {
            g = Math.Pow(9.8, 2);
            Console.WriteLine(INVITE);
            Console.WriteLine();
            Console.Write(PROVIDE_ANGLE);
            theta =degreeToRadian( float.Parse(Console.ReadLine()));
            Console.Write(PROVIDE_SPEED);
            speed = float.Parse(Console.ReadLine());
            vox = (float)(speed * Math.Cos(theta));
            voy = (float)(speed * Math.Sin(theta));
            t = (float)(voy / g);
            h = (float)((voy * voy) / (2 * g));
            dx = vox * 2 * t;
            Console.WriteLine(RESULT_HEIGHT + h.ToString(NUMBER_FORMAT)+METERS);
            Console.WriteLine(RESULT_DISTANCE + dx.ToString(NUMBER_FORMAT)+METERS);
          
                  
            }
        private static float degreeToRadian(double angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }
    }
}
