String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

int led1Pin = 13;
int led2Pin = 12;
int led3Pin = 11;

boolean isConnected = false;

void setup() {
  
  Serial.begin(9600);
  pinMode(led1Pin,OUTPUT);
  pinMode(led2Pin,OUTPUT);
  pinMode(led3Pin,OUTPUT);
}

void loop() {

if(stringComplete)
{
  stringComplete = false;
  getCommand();
 
  if(commandString.equals("LED1"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led1Pin);
      Serial.println(commandString  + " Turned ON");
    }else
    {
      turnLedOff(led1Pin);
      Serial.println(commandString  + " Turned OFF");
    }   
  }
    else if(commandString.equals("LED2"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led2Pin);
      Serial.println(commandString  + " Turned ON");
    }else
    {
      turnLedOff(led2Pin);
      Serial.println(commandString  + " Turned OFF");
    }   
  }
    else if(commandString.equals("LED3"))
  {
    boolean LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led3Pin);
      Serial.println(commandString  + " Turned ON");
    }else
    {
      turnLedOff(led3Pin);
      Serial.println(commandString  + " Turned OFF");
    }   
  }
  
  inputString = "";
}

}

boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(4,6).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(0,4);
  }
}

void turnLedOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnLedOff(int pin)
{
  digitalWrite(pin,LOW);
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

