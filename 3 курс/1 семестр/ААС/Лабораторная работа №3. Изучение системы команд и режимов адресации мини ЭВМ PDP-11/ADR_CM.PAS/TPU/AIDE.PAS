unit Aide;

interface
uses Dos,Crt;

const
     sg=$b800;

type
    mas=array[1..4000] of byte;
    ptrmas=^mas;
var
     offs,off :word;


Procedure SaveScr(x1,y1,x2,y2:byte;var scr1:pointer);
Procedure RestScr(x1,y1,x2,y2:byte;var scr1:pointer);
Procedure PWind(x1,y1,x2,y2,simb,attr:byte);
Procedure Fon(x1,y1,x2,y2,attr:byte);
Procedure LinVert(x1,y1,y2,attr,vl:byte);
Procedure LinGor(x1,x2,y1,attr,vl:byte);
Procedure PSimb(x,y,simb,attr:byte);
Procedure PText(x1,y1:byte;txt:string;attr:byte);
Procedure Ramka(x1,y1,x2,y2,attr,vl:byte);
Function  Menu(x_n,y_n,l_vib,l_prob,kol_vib,ak,at,v_menu,ram:byte;p_mas:pointer):byte;


implementation

Procedure SaveScr(x1,y1,x2,y2:byte;var scr1:pointer);
var
     i,j,k    : longint;
     scr      : ptrmas;
begin
     scr:=scr1;
     mark(scr);
     new(scr);
     offs:=((y1-1)*80+x1-1)*2;
     k:=1;
     for i:=y1 to y2 do
         begin
         off:=offs;
         for j:=x1 to x2 do
             begin
             scr^[k]:=mem[sg:offs];
             scr^[k+1]:=mem[sg:offs+1];
             offs:=offs+2;
             k:=k+2;
             end;
         offs:=off+160;
         end;
     scr1:=scr;
end;

Procedure RestScr(x1,y1,x2,y2:byte;var scr1:pointer);
var
     i,j,k    : longint;
     scr      : ptrmas;
begin
     scr:=scr1;
     offs:=((y1-1)*80+x1-1)*2;
     k:=1;
     for i:=y1 to y2 do
         begin
         off:=offs;
         for j:=x1 to x2 do
             begin
             mem[sg:offs]:=scr^[k];
             mem[sg:offs+1]:=scr^[k+1];
             offs:=offs+2;
             k:=k+2;
             end;
         offs:=off+160;
         end;
     release(scr);
     scr1:=scr;
end;

{****************  заполнение экрана   ******************************}
Procedure PWind(x1,y1,x2,y2,simb,attr:byte);
  var i,j,k : integer;

  begin
     offs:=((y1-1)*80+x1-1)*2;
     for i:=y1 to y2 do
         begin
         off:=offs;
         for j:=x1 to x2 do
             begin
             mem[sg:offs]:=simb;
             mem[sg:offs+1]:=attr;
             offs:=offs+2;
             k:=k+2;
             end;
         offs:=off+160;
         end;
  end;

Procedure Fon(x1,y1,x2,y2,attr:byte);
  var i,j,k : integer;

  begin
     offs:=((y1-1)*80+x1-1)*2;
     for i:=y1 to y2 do
         begin
         off:=offs;
         for j:=x1 to x2 do
             begin
             mem[sg:offs+1]:=attr;
             offs:=offs+2;
             k:=k+2;
             end;
         offs:=off+160;
         end;
  end;

Procedure LinVert(x1,y1,y2,attr,vl:byte);
var
   i,j  : integer;
   simb : word;
begin
    if vl=1 then simb:=$b3 else simb:=$ba;
    offs:=((y1-1)*80+x1-1)*2;
    for i:=y1 to y2 do
        begin
        mem[sg:offs]:=simb;
        mem[sg:offs+1]:=attr;
        offs:=offs+160;
        end;
end;

Procedure LinGor(x1,x2,y1,attr,vl:byte);
var
   i,j  : integer;
   simb : word;
begin
    if vl=1 then simb:=$c4 else simb:=$cd;
    offs:=((y1-1)*80+x1-1)*2;
    for i:=x1 to x2 do
        begin
        mem[sg:offs]:=simb;
        mem[sg:offs+1]:=attr;
        offs:=offs+2;
        end;
end;

{*********  вывод символа *********}
Procedure PSimb(x,y,simb,attr:byte);
begin
    offs:=((y-1)*80+x-1)*2;
    mem[sg:offs]:=simb;
    mem[sg:offs+1]:=attr;
end;

Procedure Ramka(x1,y1,x2,y2,attr,vl:byte);
{vl: 1-одинарная,2-двойная}

var
   i,j  : integer;
   simb : array[1..4] of word;
begin
    if vl=1
       then begin
{            simb[1]:='┌';simb[2]:='┐';simb[3]:='└';simb[4]:='┘';}
            simb[1]:=$da;simb[2]:=$c0;simb[3]:=$bf;simb[4]:=$d9;
            end
       else begin
{           simb[1]:='╔';simb[2]:='╗';simb[3]:='╚';simb[4]:='╝';}
            simb[1]:=$c9;simb[2]:=$c8;simb[3]:=$bb;simb[4]:=$bc;
            end;
    LinGor(x1+1,x2-1,y1,attr,vl);
    LinGor(x1+1,x2-1,y2,attr,vl);
    LinVert(x1,y1+1,y2-1,attr,vl);
    LinVert(x2,y1+1,y2-1,attr,vl);
    PSimb(x1,y1,simb[1],attr);
    PSimb(x1,y2,simb[2],attr);
    PSimb(x2,y1,simb[3],attr);
    PSimb(x2,y2,simb[4],attr);
end;

{****************  вывод текста *****************}
Procedure PText(x1,y1:byte;txt:string;attr:byte);
var
   i,k:integer;
begin
    offs:=((y1-1)*80+x1-1)*2;
    k:=0;
    for i:=1 to length(txt) do
        begin
        mem[sg:offs+k]:=ord(txt[i]);
        mem[sg:offs+k+1]:=attr;
        k:=k+2;
        end;
end;

{*****************************  меню ************************************}
Function Menu(x_n,y_n,l_vib,l_prob,kol_vib,ak,at,v_menu,ram:byte;p_mas:pointer):byte;
{l_vib  ширина выбора
 l_prob ширина пробела
 kol_vib кол-во выборов
 v_menu :1-горизонталь,2-вертикаль
 ram:  0-меню без рамки,1-рамка простая,2-рамка двойная}
type
    mas_menu = array[1..25] of string;
    mas_ptr  = ^mas_menu;
var
  i,j,k : longint;
  x_sm,y_sm : byte;
  x,y       : byte;
  x_k,y_k   : byte;
  n_vib : integer;
  sm    : word;
  b     : char;
  fl    : boolean;
  ptr_m : mas_ptr;

Procedure Nachalo;
begin
      Fon(x,y,x+l_vib,y,at);
      n_vib:=1;
      x:=x_n+1;
      y:=y_n+1;
      Fon(x,y,x+l_vib,y,ak);
end;

Procedure Konec;
begin
     Fon(x,y,x+l_vib,y,at);
     n_vib:=kol_vib;
     x:=x_n+(kol_vib-1)*x_sm+1;
     y:=y_k-1;
     Fon(x,y,x+l_vib,y,ak);
end;

Procedure Nazad;
begin
     Fon(x,y,x+l_vib,y,at);
     n_vib:=n_vib-1;
     if n_vib<1
        then begin
             n_vib:=kol_vib;
             x:=x+(kol_vib-1)*x_sm;
             y:=y+y_sm*(kol_vib-1);
             end
        else begin
             x:=x-x_sm;
             y:=y-y_sm;
             end;
     Fon(x,y,x+l_vib,y,ak);
end;

Procedure Vpered;
begin
     Fon(x,y,x+l_vib,y,at);
     n_vib:=n_vib+1;
     if n_vib>kol_vib
        then begin
             n_vib:=1;
             x:=x_n+1;
             y:=y_n+1;
             end
        else
             begin
             x:=x+x_sm;
             y:=y+y_sm;
             end;
     Fon(x,y,x+l_vib,y,ak);
end;

begin
x:=x_n+1;
y:=y_n+1;
if not((v_menu=2) and ((kol_vib+y)>25)  or
     ((v_menu=1) and ((x+kol_vib*(l_vib+l_prob))>80)))
   then begin
        ptr_m:=p_mas;
        if v_menu=1 {gor}
           then begin
                y_sm:=0;
                x_sm:=l_vib+l_prob;
                x_k:=x_n+kol_vib*x_sm;
                y_k:=y_n+2;
                end
           else begin {vert}
                 x_sm:=0;
                 y_sm:=l_prob;
                 x_k:=x_n+l_vib+2;
                 y_k:=y_n+(kol_vib-1)*(l_prob)+2;
                 end;
        if (ram=1)or(ram=2)
           then begin
                PWind(x_n,y_n,x_k,y_k,$20,at);
                Ramka(x_n,y_n,x_k,y_k,at,ram);
                end;
        for i:=1 to kol_vib do
            PText(x+(i-1)*x_sm,y+(i-1)*y_sm,ptr_m^[i],at);
        Fon(x,y,x+l_vib,y,ak);
        n_vib:=1;
        fl:=false;
        repeat
              b:=readkey;
              if b=#27 then begin fl:=true;n_vib:=0;end;
              if b=#13  then fl:=true;
              if b=#0
                 then begin
                      b:=readkey;
                      case b of
                           #71: Nachalo;
                           #79: Konec;
                           #75,#72: Nazad;
                           #77,#80: Vpered;
                           end;
                      end;
        until fl;
        menu:=n_vib;
        end;
end;

end.