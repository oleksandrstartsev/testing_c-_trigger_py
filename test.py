# -*- coding: utf-8 -*-
"""
Created on Thu Jul 16 09:33:19 2020

@author: Admin
"""

import pandas as pd
import numpy as np
import vaex

print('Here goes a python script execution. ')

df = pd.DataFrame(np.random.randint(0,255,size=(1_000_000, 4)), columns=list('ABCD'))
df['r'] = np.sqrt(df.A**2 + df.B**2 + df.C**2)

print(repr(df))


print("\n New test")

df = vaex.example()
print(repr(df))

print("\n End of processing.")