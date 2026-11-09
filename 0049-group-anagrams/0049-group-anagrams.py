class Solution:
    def isAnagram(self, str1: str, str2: str) -> bool:
        if len(str1) != len(str2):
            return False
        counts = defaultdict(int)
        for i in range(len(str1)):
            counts[str1[i]] += 1
            counts[str2[i]] -= 1
        for v in counts.values():
            if v != 0:
                return False
        return True
    def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
        # strs.sort()
        # res = []
        # temp = [[strs[0]]]
        # for i in range(1, len(strs)):
        #     if not self.isAnagram(strs[i], strs[i-1]):
        #         res.append(temp)
        #         temp = [strs[i]]
        #     else:
        #         temp.append(strs[i])
        # return res

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
                
