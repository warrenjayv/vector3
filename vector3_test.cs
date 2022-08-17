using System;

// delta time 
class time {
    public static float deltaTime; 
}

// vector in 3 dimensions
// <x(t), y(t), z(t)> = x(t)i + y(t)j + z(t)k
class vector3 {
    
    // vectors
    public float x;
    public float y;
    public float z;
    
    // direction
    public vector3 up() 
    { 
         this.x = 0; this.y = 1; this.z = 0; 
         return this; 
        
    }

    // +, * operator overloads
    public static vector3 operator*(vector3 a, float b) 
    {
        a.x *= b;  a.y *= b;  a.z *= b; 
        return a; 
    }
    public static vector3 operator+(vector3 a, float b) 
    {
        a.x += b;  a.y += b;  a.z += b; 
        return a; 
    }
    public static vector3 operator*(vector3 a, vector3 b) 
    {
        a.x *= b.x;  a.y *= b.y;  a.z *= b.z; 
        return a; 
    }
    public static vector3 operator+(vector3 a, vector3 b) 
    {
        a.x += b.x;  a.y += b.y;  a.z += b.z; 
        return a; 
    }
    public override string ToString() {
        return string.Format("{0} {1} {2}", x, y, z);
    }
    
}

// calculate the position given a force of 50 newtons and a mass of 10 kg
// in the up direction
class test_vector {
 
  static public void Main() {

        // time in 2 seconds
        time.deltaTime = 2.0f;
        
        // direction
        vector3 dir = new vector3(); 
        dir = dir.up();
        
        // position = x + vt + 0.5at^2
        vector3 pos = new vector3();
        
        // velocity = u + at 
        vector3 vel = new vector3(); 
        
        // acceleration = vd / td  ( a = F/m )
        //      5 m/s^2 = 50 newtons / 10 kg mass
        float acc   = 50 / 10; 
        
        // vel = u + at ( u = initial velocity )
        vel += dir * acc * time.deltaTime; 
        Console.WriteLine("velocity: \n < {0} > m/s ", vel);
        
        // print acceleration
        Console.WriteLine("acceleration: \n {0} m/s^2 ", acc);
        
        // pos = x + ut + 0.5at^2 ( u is 0) 
        // note: dir is needed as acceleration is also a vector
        pos += vel * time.deltaTime + dir * 0.5f * acc * time.deltaTime * time.deltaTime; 
        
        // position after 2 seconds
        Console.WriteLine("position: \n < {0} >", pos);
        
  }
}
