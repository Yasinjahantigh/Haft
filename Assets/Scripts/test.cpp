/******************************************************************************

                              Online C++ Compiler.
               Code, Compile, Run and Debug C++ program online.
Write your code in this editor and press "Run" button to compile and execute it.

*******************************************************************************/

#include <iostream>
using namespace std;

void adad_nemitony_bezari(int a, int b)
{
    int n, m, counter = 0;
    n =a* b;
    m = n;
    while(m != 0){
        m = m/10;
        coutner++;
    }
    int a[coutner];
    for(int i = 0; n != 0; i++){
        a[i] = n/10;
        n = n/10;
    }
    cout<<"hello"; // this is cout
}

int main()
{
   int a, b, n;
   cin>>a>>b;
   adad_nemitony_bezari(a, b);
}
