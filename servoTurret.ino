#include <Servo.h>

Servo servoX;
Servo servoY;
String serial_Data_Coordenates;

void setup()
{
    Serial.begin(9600);
    Serial.setTimeout(10);
    servoX.attach(3);
    servoY.attach(9);
}

void loop()
{
    // XD
}

void serialEvent()
{
    serial_Data_Coordenates = Serial.readString();
    //Serial.println("Coordenada: " + serial_Data_Coordenates);
    servoX.write(parseDataX(serial_Data_Coordenates));
    servoY.write(parseDataY(serial_Data_Coordenates));
}

int parseDataX(String data)
{
    data.remove(data.indexOf("Y"));     // It remove from "Y" to the end of the string
    data.remove(data.indexOf("X"), 1);  // It just remove 1 charactor
    return data.toInt();
}

int parseDataY(String data)
{
    data.remove(0, data.indexOf("Y") + 1);  // It removes from index 0 of the string 
    return data.toInt();                    // to the index of the charactor "Y" 
}