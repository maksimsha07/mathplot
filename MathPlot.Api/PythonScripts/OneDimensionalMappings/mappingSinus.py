import matplotlib.pyplot as plt
import numpy as np
import math
import random
def f(x):
	return r*math.sin(math.pi*x)
def ff(x,r):
	return r*math.sin(math.pi*x)
def dff(x,r):
	return math.log(math.fabs(math.pi*r*math.cos(math.pi*x)))
login = ""
loginid = ""
count = ""
r = 0.8
x = np.linspace(0.01,0.9,num = 1000)
fx = np.linspace(0,1,num = 10)
fy = np.linspace(0,1,num = 10)
y = [f(i) for i in x]
y2 = []
x2 = []
y2.append(0)
x2.append(0.1)
N = 10000
for i in range(N):
	y2.append(f(x2[-1]))
	x2.append(x2[-1])
	y2.append(y2[-1])
	x2.append(y2[-2])

plt.plot(x,y,fx,fy,x2[0:int(N/2)],y2[0:int(N/2)],'r--',x2[int(N/2):N-1],y2[int(N/2):N-1],'b--')
plt.ylim([0,1])
plt.savefig(count+login + loginid+ "sinusmapp.png")
plt.cla()
plt.clf()

nn = 10000
rb = np.linspace(0.1,0.9,nn)
xx = []
c = []
s = []
rdn = random.choice(rb)
for k in range(nn):
	xx = [rdn]
	for n in range(nn-1):
		xx.append(ff(xx[n],rb[k]))
		if(n > nn-20):
			c.append(rb[k])
			s.append(xx[-1])

plt.plot(c,s,',')
plt.ylim([0,1])
plt.savefig(count+login + loginid+ "sinusbifur.png")
plt.cla()
plt.clf()

summ = []
for j in range(nn):
	xl = [0.1]
	xll = []
	for i in range(nn-1):
		xl.append(ff(xl[i],rb[j]))
		xll.append(dff(xl[i],rb[j]))
	summ.append(sum(xll)/100)

plt.plot(rb,summ,',')
plt.savefig(count+login + loginid+ "sinuslyapunov.png")