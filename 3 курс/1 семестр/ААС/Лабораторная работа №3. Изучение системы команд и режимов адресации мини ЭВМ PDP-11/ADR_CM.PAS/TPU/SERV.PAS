Unit Serv;

interface

Uses Dos,Dcl_CTV,Crt,Crt2,Aide,Str1;

Procedure Main_menu(var quit:integer;var fin:boolean);
Procedure Vtext(x,xk,y,attr:byte;rg:registers;var res:string);
Procedure Vvod(x,xk,y,attr:byte;var res:string;var quit:integer;var fin :boolean);
Procedure V_prim(var quit:integer);
Procedure V_Merite;

const
     finfo ='files\Info'; fkod ='files\Kod'; fadr ='files\Addr';
     na:array[1..12] of integer=(2,11,23,34,47,57,70,82,97,110,142,174);
                                {(2,2,10,14,20,24,28,32,38,42,46,50);}
     vx1=5;vx2=32;vy1=8;vy2=10;

type
    mas = array[1..4000] of byte;
    ptrmas = ^mas;
    mas_menu = array[1..25] of string;
    ptr_menu = ^mas_menu;
    t_inf = string[80];
var
   fs     : file of t_inf;
   ecr,ecr1,ecr2,ecr3: pointer;
   sm     : word;
   p_menu : pointer;
   ptr_m  : ptr_menu;

implementation

Procedure Vtext(x,xk,y,attr:byte;rg:registers;var res:string);
var
   fl : boolean;
   key: byte;
   i  : byte;
begin
   window(1,1,80,25);
   Gotoxy(x,y);
   Cur(True);
   res:='';
   fl:=false;
   repeat
      case rg.al of
           $1b : begin
                 for i:=x to xk-1 do
                          Ptext(i,y,' ',attr);
                 fl:=true;
                 res:='';
                 end;
           $0d : fl:=true;
           else begin
                 case rg.al of
                      $30..$37: begin
                                res:=concat(res,char(rg.al));
                                rg.dl:=rg.al;
                                rg.ah:=$02;
                                intr($21,rg);
                                mem[sg:(80*(y-1)+x-2+length(res))*2+1]:=attr;
                                end;
                      $08: begin
                           if length(res)>0
                              then begin
                                   delete(res,length(res),1);
                                   mem[sg:(80*(y-1)+x-1+length(res))*2]:=32;
                                   mem[sg:(80*(y-1)+x-1+length(res))*2+1]:=attr;
                                   rg.dl:=$08;
                                   rg.ah:=$02;
                                   intr($21,rg);
                                   end;
                           end;
                      end;
                 if length(res)<(xk-x)
                    then begin
                         rg.ah :=$00;
                         intr($16,rg);
                         end
                     else repeat
                          rg.ah :=$00;
                          intr($16,rg);
                          until ((rg.al=$0d)or(rg.al=$08)or(rg.al=$1b));
                 end;
           end;
   until fl;
   Cur(False);
end;

Procedure ListF(n:longint);
var
   i      : integer;
   stroka : t_Inf;
begin
     clrscr;
     seek(fs,n);
     i:=1;
     while (not eof(fs))and(i<=20) do
           begin
           read(fs,stroka);
           writeln(stroka);
           i:=i+1;
           end;
end;


Procedure V_menu(fname:string;n:longint);
var
   rg : registers;
   b  : char;
   i  : integer;
begin
     savescr(1,1,80,25,ecr1);
     assign(fs,fname);
     reset(fs);
{     Pwind(1,1,80,25,176,113);}
     V_ps('Home| -начало|END- конец|PgUp -вверх|PgDn- вниз|            |ESC -выход|',113,116);
     Fon(6,3,76,23,7);
     Window(5,2,75,22);
     textcolor(0);
     textbackground(3);
     clrscr;
     repeat
     ListF(n);
     rg.ah := 00;
     intr($16,rg);
     if rg.al=00
        then begin
             case rg.ah of
                 $49: begin
                      n:=filepos(fs)-40;
                      if n<0 then n:=0;
                      end;
                 $51: n:=filepos(fs)-1;
                 $47: n:=0;
                 $4f: n:=filesize(fs)-20;
                 end;
             end
     until rg.al=$1b;
     close(fs);
     restscr(1,1,80,25,ecr1);
end;

Procedure V_Adr(fname:string);
var
   n   :longint;
   key :byte;
begin
       savescr(1,1,80,25,ecr2);
       p_menu:=addr(mva);
       key:=Menu(20,3,40,1,12,116,112,2,1,p_menu);
       if key<>0 then V_menu(fname,na[key]);
       restscr(1,1,80,25,ecr2);
end;

Procedure V_ptr(fname:string;va:integer);
var
     n:longint;
begin
    n:=na[va];
    V_menu(fname,n);
end;


Procedure V_Merite;
var
   i:integer;
   b:char;
begin
       savescr(1,1,80,25,ecr2);
       Fon(15,7,61,21,7);
       Pwind(14,6,60,20,32,112);
       Ramka(14,6,60,20,112,1);
       PText(17,7,res.ident+':',116);
       textcolor(0);
       textbackground(7);
       window(15,8,56,20);
       for i:=1 to 12 do
           writeln(mva[i]);
       textcolor(4);
       window(58,8,59,20);
       for i:=1 to 12 do
           writeln(res.mer[i]);
       b:=readkey;
       if b=#0 then b:=readkey;
       restscr(1,1,80,25,ecr2);
end;

Procedure V_prim(var quit:integer);
var
    key:byte;
begin
       savescr(1,1,80,25,ecr2);
       Getmem(p_menu,sizeof(ptr_menu));
       ptr_m:=p_menu;
       ptr_m^[1]:=' Следующий пример  ';
       ptr_m^[2]:=' Вид адресации     ';
       key:=Menu(50,3,19,1,2,116,112,2,1,p_menu);
       Freemem(p_menu,sizeof(ptr_menu));
       case key of
            1:quit:=0;
            2:begin
              savescr(1,1,80,25,ecr3);
              p_menu:=addr(mva);
              key:=Menu(38,6,40,1,12,116,112,2,1,p_menu);
              if key<>0 then quit:=-key;
              restscr(1,1,80,25,ecr3);
              end;
            end;
       restscr(1,1,80,25,ecr2);
end;

Procedure Main_menu(var quit:integer;var fin:boolean);
var
   key   : byte;
   fname : string;
begin
   repeat
       savescr(1,1,80,25,ecr);
       Getmem(p_menu,sizeof(ptr_menu));
       ptr_m:=p_menu;
       ptr_m^[1]:='  Введение';
       ptr_m^[2]:='Код операции';
       ptr_m^[3]:=' Адресация';
       ptr_m^[4]:='  Оценка';
       ptr_m^[5]:='Выбор примера';
       ptr_m^[6]:='   Выход';
{       ptr_m^[6]:='включение отображения';}
       key:=Menu(1,1,12,1,6,116,112,1,1,ptr_m);
       Freemem(p_menu,sizeof(ptr_menu));
       case key of
            1: V_menu(finfo,0);
            2: V_menu(fkod,0);
            3: V_Adr(fadr);
            4: V_merite;
            5: V_prim(quit);
            6: fin:=true;
            end;
       restscr(1,1,80,25,ecr);
   until (key=0) or (key=5) or fin;
end;


Procedure Vvod(x,xk,y,attr:byte;var res:string;var quit:integer;var fin :boolean);
var
   rg   : registers;
   fl   : boolean;
   key  : byte;

begin
   Cur(true);
   fl:=false;
   repeat
         rg.ah := 00;
         intr($16,rg);
         if rg.al=00
            then begin
                 Cur(false);
                 case rg.ah of
                      $44: Main_menu(quit,fin);
                      $1e: V_ptr(fadr,quit);{V_Adr(fadr);}
                      $23: V_menu(finfo,0);
                      $2e: V_menu(fkod,0);
                      $13: V_merite;
                      $10: fin:=true;
                      $78: V_menu(fadr,na[1]);
                      $79: V_menu(fadr,na[2]);
                      $7a: V_menu(fadr,na[3]);
                      $7b: V_menu(fadr,na[4]);
                      $7c: V_menu(fadr,na[5]);
                      $7d: V_menu(fadr,na[6]);
                      $7e: V_menu(fadr,na[7]);
                      $7f: V_menu(fadr,na[8]);
                      $80: V_menu(fadr,na[9]);
                      $81: V_menu(fadr,na[10]);
                      $82: V_menu(fadr,na[11]);
                      $83: V_menu(fadr,na[12]);
                      end;
                 res:='*';
                 fl:=true;
                 end
            else begin
                 if rg.ah<>$d then Vtext(x,xk,y,attr,rg,res);
                 Cur(false);
                 fl:=true;
                 end;
    until  fl {or quit} or fin;
end;

end.