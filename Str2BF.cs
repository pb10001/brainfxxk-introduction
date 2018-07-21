using System;
using System.Collections.Generic;
using System.Linq;
public class Program{
    public static void Main(){
        /* ASCII文字列を標準入力から受け取って、同じ文字列を出力するBFのコードを返す */
        var line = System.Console.ReadLine();
        var array = new CharArray(line);
        var res = array.DifArray().Select(x=>new BFBuilder(x).Build());
        Console.WriteLine(string.Join("",res));
    }
}
public class CharArray{
    public CharArray(string str){
        value = str;
    }
    string value;
    public IEnumerable<int> DifArray(){
        yield return value[0];
        for(int i=1;i<value.Length;i++){
            yield return value[i] - value[i-1];
        }
    }
}
public class BFBuilder{
    public BFBuilder(int n){
        num = n;
    }
    int num;
    public string Build(){
        return Build("",num);
    }
    public string Build(string tmp, int num){
        if(Math.Abs(num) < 10){
            for(int i=0;i<Math.Abs(num);i++){
                if(num > 0)
                    tmp+="+";
                else
                    tmp += "-";
            }
            tmp += ".";
        }
        else{
            tmp += ">";
            for(int i=0;i<Math.Abs(num)/10;i++){
                tmp += "+";
            }
            if(num < 0)
                tmp += "[<---------->-]<";
            else
                tmp += "[<++++++++++>-]<";
            tmp = Build(tmp, num%10);
        }
        return tmp;
    }
}
