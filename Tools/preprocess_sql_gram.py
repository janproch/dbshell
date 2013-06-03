import sys, os, os.path

def process_file(fn):
    mode = 'copy'
    
    for line in open(fn, 'r'):
        line = line.rstrip()
        if line == '#end':
            mode = 'copy'
        elif line == '#keywords':
            mode = 'keywords'
        elif line == '#sysnames':
            mode = 'sysnames'
        elif line.startswith('#include'):
            fn2 = line[8:].strip()
            process_file(os.path.join(basedir, fn2))
        else:
            if mode == 'copy':
                print >>fw, line
            elif mode in ['keywords', 'sysnames']:
                if line == '': continue
                
                if mode == 'keywords': keywords.append(line)
                if mode == 'sysnames': sysnames.append(line)
                s = line + ' :'
                for c in line:
                    s += ' '
                    if c == '_':
                        s += "'_'"
                    else:
                        s += c
                s += ';'
                print >>fw, s


fw = open(sys.argv[2], 'w')
keywords = []
sysnames = []
basedir = os.path.split(sys.argv[1])[0]

process_file(sys.argv[1])

                                  
print >>fw, 'keyword :'
print >>fw, '|'.join(keywords)
print >>fw, ';'

print >>fw, 'sysname :'
print >>fw, '|'.join(sysnames)
print >>fw, ';'
