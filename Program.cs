public class Program
{
    static int SeqSearch(int[] arr, int value){
        int i = 0;
        while(arr[i]!=value)
            i++;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value){
        if(arr[from]==value)
            return from;
        else
            return RecuSearch(arr, from+1, value);
    }
    static int RecuSearch2(Array arr, int value){
        if((int)arr.GetValue(arr.GetLowerBound(0))==value)
            return arr.GetLowerBound(0);
        else{
            Array temp = Array.CreateInstance(typeof(int), 
                        new int[]{arr.Length-1}, 
                        new int[]{arr.GetLowerBound(0)+1});
            /*Array.Copy(arr, temp.GetLowerBound(0), 
                temp, temp.GetLowerBound(0), temp.Length);*/
            for(int i=temp.GetLowerBound(0); i<temp.Length; i++)
                temp.SetValue(arr.GetValue(i), i);
            return RecuSearch2(temp, value);
        }
    }
    static int RecuSearch3(List<int> arr, int value){
        List<int> temp = new List<int>(arr);
        if(temp[0]==value)
            return 0;
        else{
            temp.RemoveAt(0);
            return 1 + RecuSearch3(temp, value);
        }
    }
    public static void Main(string[] args){
        Console.Clear();
        int[] arr = {7, 9, 4, 6, 10}; int value = 4;
        int result = SeqSearch(arr, value);
        Console.WriteLine("Sequential Search: " + result);
        result = RecuSearch(arr, 0, value);
        Console.WriteLine("Recursive Search: " + result);
        result = RecuSearch2(arr, value);
        Console.WriteLine("Recursive Search 2: " + result);
        List<int> list = new List<int>(arr);
        result = RecuSearch3(list, value);
        Console.WriteLine("Recursive Search 3: " + result);
    }
}