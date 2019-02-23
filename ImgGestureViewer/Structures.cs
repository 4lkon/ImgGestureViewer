using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//lista dostepnych kamer, ich nazwa oraz Id
struct Video_Device
{
    public string Device_Name;
    public int Device_ID;

    public Video_Device(int ID, string Name, Guid classID)
    {
        Device_ID = ID;
        Device_Name = Name;
    }
    public override string ToString()
    {
        return String.Format("[{0}] {1}", Device_ID, Device_Name);
    }
}

