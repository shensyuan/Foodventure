using System;
using System.Threading.Tasks;

class Utils {
    static public async void SetTimeout(Action func, int count) {
        await Task.Delay(count);
        func();
    }
}
