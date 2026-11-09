class Solution:
    def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
        seen = {}
        res = []
        for i in range(len(strs)):
            temp = ''.join(sorted(strs[i]))
            if temp in seen:
                res[seen[temp]].append(strs[i])
            else:
                seen[temp] = len(res)
                res.append([strs[i]])
        return res
                
