
bool bandera=true;
float centigrados(){
float dato;
float cent;
dato= analogRead(A1);
cent=(5.0*dato*100)/1024.0;
return cent;
}
float kelvin(float centigrados){
  float kelvin;
  kelvin=centigrados +273.15;
  return kelvin;
  }

 float fahrenheit(float centigrados){
  float fahr;
  fahr= centigrados*1.8 + 32;
  return fahr;
  } 
void setup() {
Serial.begin(9600);


}

void loop() {
 float centigra=centigrados();
 float Kelvin=kelvin(centigra);
 float Fahr=fahrenheit(centigra);
 delay(1000);
 if(bandera){
 //Serial.println("Temperatura");
// Serial.println("Centigrados\t Kelvin\t Fahrenheit");
  delay(200);
  bandera=false;
 }
 else{
  delay(1000);
//  Serial.println(String (centigra)+"\t\t"+ String(Kelvin)+ "\t\t"+String( Fahr));
Serial.println(centigra);

  }
}
