import os, os.path, re, sys

def enum_cs_files():
    for folder in ['..', '../../dbmouse']:
        for root, dirs, files in os.walk(folder):
            if '.svn' in dirs:
                dirs.remove('.svn')
            if '.bld' in dirs:
                dirs.remove('.bld')
            if 'Install' in dirs:
                dirs.remove('Install')
            if 'install' in dirs:
                dirs.remove('install')
            if 'obj' in dirs:
                dirs.remove('obj')
        
            for name in files:
                fn = os.path.join(root, name)
                if fn.endswith('.cs'):
                    yield fn

errs = {}
uerrs = []
dups = []


for fn in enum_cs_files():
    print >>sys.stderr, 'Processing file:', fn
    data = open(fn).read()
    pat = re.compile(r'DBSH\-(\d\d\d\d\d)')
    for m in pat.finditer(data):
        s = m.group(1)
        if s == '00000':
            uerrs.append({
                'file': fn
            })
        elif s in errs:
            dups.append({
                'file': fn,
                'code': s
            })
        else:
            errs[s] = {
                'file': fn
            }

print 'Defined errors:', len(errs)
for code in sorted(errs):
    err = errs[code]
    print code, err['file']
    
print    

print 'Undefined errors:', len(uerrs)
for err in uerrs:
    print err['file']

print    

print 'Duplicates:', len(dups)
for err in dups:
    print err['code'], err['file']
    print 'OTHER:', errs[err['code']]['file']

used = errs.keys()
if len(used) == 0:
  used.append(0)

if len(sys.argv) >= 2 and sys.argv[1] == 'assign':
    for fn in enum_cs_files():
        data = open(fn, 'rb').read()
        changed = False
        while 'DBSH-00000' in data:
            changed = True
            nextcode = '%05d' % (int(max(used)) + 1)
            used.append(nextcode)
            data = data.replace('DBSH-00000', 'DBSH-' + nextcode, 1) 
        if changed:
            print >>sys.stderr, 'Updating file:', fn
            open(fn, 'wb').write(data)
