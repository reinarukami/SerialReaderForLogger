String deviceID = "96D88A707C3CA2AB203348A64CC55CD41E800248";      
int inputPin = 2;               // choose the input pin (for PIR sensor)
int pirState = LOW;             // we start, assuming no motion detected
int val = 0;                    // variable for reading the pin status
int count = 0;


void setup() {
  pinMode(inputPin, INPUT);     // declare sensor as input
  
  Serial.begin(9600);
}
 
void loop(){
  val = digitalRead(inputPin);  // read input value
  if (val == HIGH) {            // check if the input is HIGH
    if (pirState == LOW) {
      // we have just turned on
      count++;
      Serial.flush();
    
      Serial.println("{'deviceID':'" + deviceID + "'," + "'values':'Motion Detected=" + count +"'}" ) ; 
      Serial.flush();
      // We only want to print on the output change, not state
     pirState = HIGH;
    }
  } else {
      pirState = LOW;
    
    }
  }
