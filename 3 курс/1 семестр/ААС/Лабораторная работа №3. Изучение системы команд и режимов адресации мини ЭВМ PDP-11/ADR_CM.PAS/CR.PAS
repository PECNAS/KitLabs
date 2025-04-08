Program In_Cmnd;
Uses Dos,Crt,Crt2,Aide,Serv,Str1,Dcl_CTV;

const
     sg=$b800;
     cmax=3;
     mpx1=24;mpy1=5;mpx2=44;mpy2=8;
     msx1=22;msy1=7;msx2=42;msy2=10;  { WINDOWS OF MENU}
     mtx1=20;mty1=10;mtx2=40;mty2=24;
     vx1=3;   vx2=77; vy1=2;  vy2=23;  {окно ввода машинного кода }
     kx1=33;  kx2=55; ky1=2;  ky2=10;  {окно команды на ассемблере}
     rx1=3+1+3; rx2=3+5+8; ry1=16; ry2=23; {окно ввода}
     rx3=3+19;rx4=3+23+8;
     rx5=3+33;rx6=3+40+8;
     rx7=3+47;rx8=3+57+8;
     rx9=3+60;rx10=3+67+8;
     fcom ='files\Cmnd';

type
    t_Com =record
           n   :1..2;
           k   :2..4;
           cod :string[30];
           kop :string[4];
           op  :array[1..4] of string[1];
           ext :array[1..2] of string[6];
           nr  :integer;
           rego :array[0..7] of string[6];
           regn :array[0..7] of string[6];
           nm   :integer;
           mema :array[1..6] of string[6];
           memo :array[1..6] of string[6];
           memn :array[1..6] of string[6];
           end;
var
   i,j    : integer;
   kom    : string;
   kop    : string[4];
   op     : array[1..4] of string[1];
   nzp    : longint;
   fc     : file of t_Com;
   com    : t_Com;
   ucas_r : array[1..12] of word;
   b      : char;
   key,key1,key2 : byte;
   fname  : string;
   exts   : string[2];

Procedure Mess(txt:string;attr:byte);
var
  x:integer;
  l:integer;
begin
        savescr(1,1,80,25,ecr);
        l:=length(txt);
        x:=(80-(l+4)) div 2;
        Fon(x+1,10+1,80-x+1,12+1,7);
        PWind(x,10,80-x,12,32,attr);
        Ptext(x+2,11,txt,attr);
        b:=readkey;
        if b=#0 then b:=readkey;
        restscr(1,1,80,25,ecr);
end;

Procedure Image;
begin
   textcolor(14);
   textbackground(1);
   Window(1,1,80,24);
   clrscr;
   Ramka(1,1,80,24,31,2);
   Window(2,2,80,24);
   writeln('Команда на Ассемблере :');
   writeln('Количество адресов :');
   writeln('Код операции :');
   writeln('Режим адресации 1 операнда :');
   writeln('Номер регистра 1 операнда  :');
   writeln('Режим адресации 2 операнда :');
   writeln('Номер регистра 2 операнда  :');
   writeln('Расширение адр. 1 операнда :');
   writeln('Расширение адр. 2 операнда :');
   writeln('К-во регистров, изменивших состояние:');
   writeln('К-во ячеек памяти, изменивших состояние:');
   writeln;
   writeln('         Регистры                             Память:');
   writeln('  до операции       после         Адрес      до операции       после');
   for i:=0 to 7 do
       writeln(' R',i);
end;

Procedure Vpar(x,y,len,attr:byte;var res:string);
var
   fl : boolean;
   key: byte;
   rg:registers;
   pole :string;
begin
   pole:='                                                   ';
   window(1,1,80,25);
   PWind(x,y,x+len-1,y,32,attr);
   Gotoxy(x,y);
   res:='';
   fl:=false;
   repeat
      rg.ah:=00;
      intr($16,rg);
      if length(res)<len
         then begin
              case rg.al of
                   $1b : begin
                         pole[0]:=char(len);
                         Ptext(x,y,pole,attr);
                         fl:=true;
                         res:='';
                         end;
                   $0d : fl:=true;
                   $20,$22..$fb: begin
                                 res:=concat(res,char(rg.al));
                                 rg.dl:=rg.al;
                                 rg.ah:=$02;
                                 intr($21,rg);
                                 mem[sg:(80*(y-1)+x-2+length(res))*2+1]:=attr;
                                 end;
                   $08: if length(res)>0
                           then begin
                                delete(res,length(res),1);
                                mem[sg:(80*(y-1)+x-1+length(res))*2]:=32;
                                mem[sg:(80*(y-1)+x-1+length(res))*2+1]:=attr;
                                rg.dl:=$08;
                                rg.ah:=$02;
                                intr($21,rg);
                                end;
                   end;
              end
         else case rg.al of
                   $0d:fl:=true;
                   $08: begin
                        delete(res,length(res),1);
                        mem[sg:(80*(y-1)+x-1+length(res))*2]:=32;
                        mem[sg:(80*(y-1)+x-1+length(res))*2+1]:=attr;
                        rg.dl:=$08;
                        rg.ah:=$02;
                        intr($21,rg);
                        end;
              end;
   until fl;
end;

Procedure EnterRec;
var
   par : string;
   cc  : integer;
   chif: word;
   k   : byte;
begin
     Window(kx1,ky1,kx2,ky2);
     clrscr;
     Window(rx1,ry1,79,ry2);
     clrscr;
     pwind(kx1+10,ky1+9,kx1+11,ky1+10,32,30);
     gotoxy(kx1,ky1);
{cop}
     repeat
           Vpar(kx1,ky1,30,112,par);
           while (par[1]=' ')and(length(par)>1) do
                 delete(par,1,1);
     until (par<>'')and(par<>' ');
     com.cod:=par;
     Ptext(kx1,ky1,com.cod,112);
{к-во оп}
     repeat
           Vpar(kx1,ky1+1,1,112,par);
           val(par,com.n,cc)
     until (cc=0)and((com.n=1)or(com.n=2));
     Ptext(kx1,ky1+1,par,112);
     if com.n=1 then com.k:=4 else com.k:=2;
{}
     repeat
           Vpar(kx1,ky1+2,com.k,112,par);
           while (par[1]=' ')and(length(par)>1) do
                 delete(par,1,1);
           val(par,chif,cc)
     until cc=0;
     while length(par)<com.k do
           insert('0',par,1);
     com.kop:=par;
     Ptext(kx1,ky1+2,com.kop,112);
{}
     for i:=1 to com.n*2 do
         begin
         repeat
               Vpar(kx1,ky1+2+i,1,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (cc=0)and(chif>=0)and(chif<=7);
         Ptext(kx1,ky1+2+i,par,112);
         com.op[i]:=par;
         end;
     com.ext[1]:='';com.ext[2]:='';
{}
     for i:=1 to com.n do
         begin
         repeat
               Vpar(kx1,ky1+6+i,6,112,par);
               com.ext[i]:=par;
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (par='')or(cc=0);
         if par<>'' then while length(par)<6 do
                         insert('0',par,1);
         Ptext(kx1,ky1+6+i,par,112);
         end;
{}
     repeat
           Vpar(kx1+10,ky1+9,1,112,par);
           val(par,com.nr,cc)
     until (cc=0)and(com.nr>=0)and(com.nr<=7);
{}
     repeat
           Vpar(kx1+10,ky1+10,1,112,par);
           val(par,com.nm,cc)
     until (cc=0)and(com.nm>=0)and(com.nm<=7);
{}
     for i:=0 to 7 do
         begin
         repeat
               Vpar(rx1,ry1+i,6,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (cc=0);
         while length(par)<6 do
               insert('0',par,1);
         Ptext(rx1,ry1+i,par,112);
         com.rego[i]:=par;
         end;
     for i:=0 to 7 do
         begin
         com.regn[i]:=com.rego[i];
         Ptext(rx3,ry1+i,com.regn[i],112);
         end;
{}
     for i:=0 to 7 do
         begin
         repeat
               Vpar(rx3,ry1+i,6,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (cc=0) or (par='');
         if par<>''
            then begin
                 while length(par)<6 do
                       insert('0',par,1);
                       com.regn[i]:=par;
                 end;
         Ptext(rx3,ry1+i,com.regn[i],112);
         end;
{}
     for i:=1 to 6 do
         begin
         repeat
               Vpar(rx5,ry1+i,6,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (cc=0);
         while length(par)<6 do
               insert('0',par,1);
         Ptext(rx5,ry1+i,par,112);
         com.mema[i]:=par;
         end;
{}
     for i:=1 to 6 do
         begin
         repeat
               Vpar(rx7,ry1+i,6,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc);
               k:=1;
               repeat
                    if (par[k]<'0')or(par[k]>'7')
                       then cc:=cc+1;
                    k:=k+1;
               until k>length(par);
         until (cc=0);
         while length(par)<6 do
               insert('0',par,1);
         Ptext(rx7,ry1+i,par,112);
         com.memo[i]:=par;
         end;
{}
     for i:=1 to 6 do
         begin
         com.memn[i]:=com.memo[i];
         Ptext(rx9,ry1+i,com.memn[i],112);
         end;
{}
     for i:=1 to 6 do
         begin
         repeat
               Vpar(rx9,ry1+i,6,112,par);
               while (par[1]=' ')and(length(par)>1) do
                     delete(par,1,1);
               val(par,chif,cc)
         until (cc=0) or (par='');
         if par<>''
            then begin
                 while length(par)<6 do
                       insert('0',par,1);
                       com.memn[i]:=par;
                 end;
         Ptext(rx9,ry1+i,com.memn[i],112);
         end;
end;

Procedure Vvod(nzp:longint);
begin
   seek(fc,nzp);
   Image;
   b:=#13;
   while b<>#27 do
       begin
       V_ps('ENTER -ввод очередной записи                       |ESC -выход|',113,116);
       b:=readkey;
       PWind(1,25,80,25,32,31);
       case b of
          #00: b:=readkey;
          #13: begin
               EnterRec;
               write(fc,com);
               end;
          end;
       end;
   close(fc);
end;

Procedure Corr;
var
   rg :registers;
   ck : t_Com;
   par:string;
   Ud :array[byte] of boolean;
   f,fl :boolean;

   Procedure  ListRec;
   var
      z:string;
   begin
        PText(kx1,ky1,com.cod,31);
        str(com.n,par);
        Ptext(kx1,ky1+1,par,31);
        Ptext(kx1,ky1+2,com.kop,31);
        for i:=1 to com.n*2 do
            Ptext(kx1,ky1+2+i,com.op[i],31);
        for i:=1 to 2 do
            Ptext(kx1,ky1+6+i,com.ext[i],31);
        str(com.nr,par);
        Ptext(kx1+10,ky1+9,par,31);
        str(com.nm,par);
        Ptext(kx1+10,ky1+10,par,31);
        for i:=0 to 7 do
            Ptext(rx1,ry1+i,com.rego[i],31);
        for i:=0 to 7 do
            Ptext(rx3,ry1+i,com.regn[i],31);
        for i:=1 to 6 do
            Ptext(rx5,ry1+i,com.mema[i],31);
        for i:=1 to 6 do
            Ptext(rx7,ry1+i,com.memo[i],31);
        for i:=1 to 6 do
            Ptext(rx9,ry1+i,com.memn[i],31);
        end;

   Procedure DeleteRec;
   var
      vc   : file of t_Com;
      f    : boolean;
   begin
        assign(vc,fexpand(fcom+'_tmp'));
        rewrite(vc);
        seek(fc,0);
        f:=false;
        while not(eof(fc)) do
              begin
              read(fc,com);
              if not(Ud[filepos(fc)-1])
                 then write(vc,com)
                 else f:=true;
              end;
        if f then begin
                  close(fc);
                  erase(fc);
                  close(vc);
                  rename(vc,fname);
                  assign(fc,fname);

                  end;
   end;

   Procedure SaveRec;
   begin
        seek(fc,nzp);
        com.cod:=ck.cod;
        com.n:=ck.n;
        com.kop:=ck.kop;
        for i:=1 to com.n*2 do
            com.op[i]:=ck.op[i];
        for i:=1 to 2 do
            com.ext[i]:=ck.ext[i];
        com.nr:=ck.nr;
        com.nm:=ck.nm;
        for i:=0 to 7 do
            com.rego[i]:=ck.rego[i];
        for i:=0 to 7 do
            com.regn[i]:=ck.regn[i];
        for i:=1 to 6 do
            com.mema[i]:=ck.mema[i];
        for i:=1 to 6 do
            com.memo[i]:=ck.memo[i];
        for i:=1 to 6 do
            com.memn[i]:=ck.memn[i];
        write(fc,com);
   end;

Procedure Hexstr(len:byte;var par:string;var cc:integer);
  begin
  for i:=1 to len-length(par) do
      insert('0',par,1);
  for i:=1 to length(par) do    {либо пpовеpять сам КОП}
      case par[i] of
          '0'..'7':;
           else cc:=1;
           end;
  end;

   Procedure EnterRecKorr;
   var
      par :string;
      cc  :integer;
      i   :byte;

   begin
        textcolor(4);
        textbackground(7);
{команда на ассемблеpе}
              Vpar(kx1,ky1,30,112,par);
        if par=''
           then ck.cod:=com.cod
           else ck.cod:=par;
        PText(kx1,ky1,ck.cod,31);
        cc:=0;
{к-во опеpандов : 1 или 2}
        repeat
              cc:=0;
              Vpar(kx1,ky1+1,1,112,par);
              if par=''
                 then ck.n:=com.n
                 else begin
                      val(par,ck.n,cc);
                      if cc=0
                         then if ck.n=1 then par:='1'
                                        else if ck.n=2 then par:='2'
                                                       else cc:=1;
                      end;
        until cc=0;
        str(ck.n,par);
        Ptext(kx1,ky1+1,par,31);
        if ck.n=1 then ck.k:=4 else ck.k:=2;
{код опеpации : цифpы от 0 до 7}
        repeat
               cc:=0;
               Vpar(kx1,ky1+2,com.k,112,par);
               if par=''
                  then ck.kop:=com.kop
                  else begin
                       Hexstr(com.k,par,cc);
                       ck.kop:=par;
                       end;
        until cc=0;
        Ptext(kx1,ky1+2,ck.kop,31);
{}
        for i:=1 to ck.n*2 do
             begin
             repeat
             cc:=0;
             Vpar(kx1,ky1+2+i,1,112,par);
             if par=''
                then ck.op[i]:=com.op[i]
                else begin
                     ck.op[i]:=par;
                     case par[1] of
                          '0'..'7':;
                          else cc:=1;
                          end;
                     end;
             until cc=0;
             Ptext(kx1,ky1+2+i,ck.op[i],31);
             end;
        for i:=1 to 2 do
             begin
             repeat
             cc:=0;
             Vpar(kx1,ky1+6+i,6,112,par);
             if par='' then ck.ext[i]:=com.ext[i]
                       else if par='-'
                               then ck.ext[i]:=''
                               else begin
                                    Hexstr(6,par,cc);
                                    ck.ext[i]:=par;
                                    end;
             until cc=0;
             Ptext(kx1,ky1+6+i,ck.ext[i],31);
             end;
        cc:=0;
        repeat
              Vpar(kx1+10,ky1+9,1,112,par);
              if par='' then ck.nr:=com.nr
                        else begin
                             val(par,ck.nr,cc);
                             if ck.nr>8 then cc:=1;
                             end;
        until cc=0;
        str(ck.nr,par);
        Ptext(kx1+10,ky1+9,par,31);
        cc:=0;
        repeat
              Vpar(kx1+10,ky1+10,1,112,par);
              if par='' then ck.nm:=com.nm
                        else begin
                             val(par,ck.nm,cc);
                             if ck.nr>6 then cc:=1;
                             end;
        until cc=0;
        str(ck.nm,par);
        Ptext(kx1+10,ky1+10,par,31);
        for i:=0 to 7 do
             begin
             repeat
             cc:=0;
             Vpar(rx1,ry1+i,6,112,par);
             if par='' then ck.rego[i]:=com.rego[i]
                       else begin
                            Hexstr(6,par,cc);
                            ck.rego[i]:=par;
                            end;
             until cc=0;
             Ptext(rx1,ry1+i,ck.rego[i],31);
             end;
        for i:=0 to 7 do
             begin
             Vpar(rx3,ry1+i,6,112,par);
             if par='' then ck.regn[i]:=com.regn[i]
                       else begin
                            Hexstr(6,par,cc);
                            ck.regn[i]:=par;
                            end;
             Ptext(rx3,ry1+i,ck.regn[i],31);
             end;
        for i:=1 to 6 do
             begin
             repeat
             cc:=0;
             Vpar(rx5,ry1+i,6,112,par);
             if par='' then ck.mema[i]:=com.mema[i]
                       else begin
                            Hexstr(6,par,cc);
                            ck.mema[i]:=par;
                            end;
             until cc=0;
             Ptext(rx5,ry1+i,ck.mema[i],31);
             end;
        for i:=1 to 6 do
             begin
             repeat
             cc:=0;
             Vpar(rx7,ry1+i,6,112,par);
             if par='' then ck.memo[i]:=com.memo[i]
                       else begin
                            Hexstr(6,par,cc);
                            ck.memo[i]:=par;
                            end;
             until cc=0;
             Ptext(rx7,ry1+i,ck.memo[i],31);
             end;
        for i:=1 to 6 do
             begin
             repeat
             cc:=0;
             Vpar(rx9,ry1+i,6,112,par);
             if par='' then ck.memn[i]:=com.memn[i]
                       else begin
                            Hexstr(6,par,cc);
                            ck.memn[i]:=par;
                            end;
             until cc=0;
             Ptext(rx9,ry1+i,ck.memn[i],31);
             end;
   end;

begin
   for i:=0 to 255 do
       Ud[i]:=false;
   fl:=false;
   nzp:=0;
   repeat
      Image;
      V_ps('PgDn -вперед|PgUp -назад|ENTER -корректировка|Del -удаление|ESC -выход|',113,116);
      seek(fc,nzp);
      read(fc,com);
      ListRec;
      if Ud[nzp]
         then fon(2,2,79,23,7);
      rg.ah:=00;
      intr($16,rg);
      case rg.al of
{вп-наз}   $00 : case rg.ah of
                      $49: begin
                           nzp:=nzp-1;
                           if nzp<0 then nzp:=0;{PgUp}
                           end;
                      $51: begin
                           nzp:=nzp+1;
                           if nzp=filesize(fc) then nzp:=filesize(fc)-1;{PgDn}
                           end;
                      $53: Ud[nzp]:=not(Ud[nzp]);{Del}
                      end;
{удалить}  $1b : begin
                 DeleteRec;
                 fl:=true;
                 end;
{коррект}  $0d : begin
                 if not(Ud[nzp])
                    then begin
                         V_ps('F10 -выход c coxp.|ESC -выход без coxp.|',113,116);
                         EnterRecKorr;
                         f:=false;
                         repeat
                               rg.ah:=00;
                               intr($16,rg);
                               case rg.al of
                                    $1b:f:=true;
                                    $00:if rg.ah=$44
                                           then begin
                                                SaveRec;
                                                f:=true;
                                                end;
                                    end;
                         until f;
                         end;
                   end;
              end;
   until fl;
end;

Begin
{       assign(fc,fcom);}
 repeat
       Pwind(1,1,80,25,176,113);
       Getmem(p_menu,sizeof(ptr_menu));
       ptr_m:=p_menu;
       ptr_m^[1]:=' Ввод        ';
       ptr_m^[2]:=' Просмотр,Корректировка и удаление ';
       key:=Menu(mpx1,mpy1,35,1,2,116,112,2,1,ptr_m);
       Freemem(p_menu,sizeof(ptr_menu));
       case key of
            0:;
            1: begin
               savescr(1,1,80,25,ecr);
               Getmem(p_menu,sizeof(ptr_menu));
               ptr_m:=p_menu;
               ptr_m^[1]:=' Ввод с очисткой ';
               ptr_m^[2]:=' Дополнение      ';
               key2:=Menu(msx1,msy1,20,1,2,116,112,2,1,ptr_m);
               Freemem(p_menu,sizeof(ptr_menu));
               if key2<>0
                  then begin
                        p_menu:=addr(mva);
                        key1:=Menu(mtx1,mty1,40,1,12,116,112,2,1,p_menu);
                        if key1<>0
                           then begin
                                str(key1,exts);
                                fname:=fcom+exts;
                                assign(fc,fexpand(fname));
                                case key2 of
                                     0:;
                                     1:begin
                                       rewrite(fc);
                                       nzp:=0;
                                       end;
                                     2:begin
                                       {$i-}
                                       reset(fc);
                                       {$i+}
                                       if ioresult<>0
                                          then begin
                                               rewrite(fc);
                                               nzp:=0;
                                               end
                                          else nzp:=filesize(fc);
                                       end;
                                     end;
                                if key2<>0 then Vvod(nzp);
                                end;
                       restscr(1,1,80,25,ecr);
                       end;
               end;
            2: begin
               savescr(1,1,80,25,ecr);
               p_menu:=addr(mva);
               key1:=Menu(mtx1,mpy1+3,40,1,12,116,112,2,1,p_menu);
               if key1<>0
                  then begin
                       str(key1,exts);
                       fname:=fcom+exts;
                       assign(fc,fexpand(fname));
                       {$i-}
                       reset(fc);
                       {$i+}
                       if ioresult<>0
                          then Mess('Этот раздел отсутствует',78)
                          else if filesize(fc)=0
                                  then Mess('Этот раздел пуст',78)
                                  else  Corr;
                       end;
               restscr(1,1,80,25,ecr);
               end;
            end;
  until key=0;
end.
