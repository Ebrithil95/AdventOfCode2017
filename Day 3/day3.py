import math

input = 277678

#https://math.stackexchange.com/a/163101
def spiral(n):
        k=math.ceil((math.sqrt(n)-1)/2)
        t = 2*k+1
        m = t * t
        t -= 1
        if n>=m-t:
            return (k-(m-n),-k)
        m=m-t
        if n>=m-t:
            return (-k,-k+(m-n))
        m=m-t
        if n>=m-t:
            return (-k+(m-n),k)
        return (k,k-(m-n-t))

def manhattan_distance(start, end):
    sx, sy = start
    ex, ey = end
    return abs(ex - sx) + abs(ey - sy)

print(manhattan_distance((0,0), spiral(input)))