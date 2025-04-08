program Modif;
uses dos,crt;
type
    ts=string[80];
var
   a :file of ts;
   b :text;
   s :ts;
   i :integer;
   mptr:array[1..13] of longint;

begin
   assign(b,'addr.txt');
   reset(b);
   assign(a,'addr');
   rewrite(a);
   i:=1;
   while not(eof(b)) do
        begin
        readln(b,s);
        if copy(s,1,1)='.'
           then begin
                mptr[i]:=filepos(a);
                i:=i+1;
                end;
        write(a,s);
        end;
   mptr[13]:=filesize(a);
end.