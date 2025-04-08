.model tiny

.data
    x db 10110110b

.code

N:
    push cs
    push ds
;;;;;;;;;;;;;;;;;;;;
    mov ah, x
    mov bh, 01000100b
    xor ah, bh
    
    mov x, ah
    
;;;;;;;;;;;;;;;;;;;;
    mov ax, 4c00h
    int 21h

end N