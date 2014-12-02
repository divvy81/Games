int value[4];
int gap=200;
int flag=0,past=0;
int ans=0;
int max_val=0;
int threshold=100;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
value[0]=analogRead(1);
value[1]=analogRead(2);
value[2]=analogRead(3);
value[3]=analogRead(4);
for(int i=0;i<4;i++)
{
  value[i]=constrain(value[i], 0, 1023);
}

/*Serial.print(value[0]);
Serial.print('\t');
Serial.print(value[1]);
Serial.print('\t');
Serial.print(value[2]);
Serial.print('\t');
Serial.print(value[3]);
Serial.print('\t');
*/
max_val=value[0];
if(value[0]>threshold) ans=1;
for(int i=1;i<=3;i++)
{
  if(max_val<value[i] && value[i]>threshold)
  {
    max_val=value[i];
    ans=i+1;
  }
}
delay(100);
/*
if(flag==0)
{
past=ans;
flag=1;
}
if(past!=ans)
{
  
   flag=0;
  delay(gap);
}
*/
//Serial.println(ans);
Serial.write(ans);
}

/*
float analogToLoad(float analogval)
{
  float load=(analogval - analogvalB) * (loadB - loadA) / (analogvalA - analogvalB) + loadA;
  return load;
}

int intialize(int cellNo)
{

  float sum=0;
  for(int i=0;i<10;i++)
  {
    float weight=analogToLoad(analogRead(cellNo));
    sum=sum+weight;
    delay(200);
  }
  return sum/10;
}
*/

